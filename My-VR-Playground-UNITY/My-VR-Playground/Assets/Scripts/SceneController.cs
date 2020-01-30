﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

// I'm inheriting from my "Singleton Don't Destroy" script. Can be found among my gists.

/// <summary>
/// Switch the canvas' Render Mode to "world space" (in the inspector).
/// Script needs a reference to an image on a Canvas. Script will find and set "MainCamera" into event camera.
/// Image will scale according to the using screen. Image will fade in and out between the scenes when called.
/// Set off the image via the inspector.
/// </summary>
public class SceneController : SingletonDontDestroy<SceneController>
{
    [SerializeField]
    private Image _blackImageFader;

    [SerializeField]
    private Canvas _sceneFader;

    private Vector3 _smallForward = new Vector3(0, 0, 0.4f);

    private void Start()
    {
        CanvasInitialization();
    }

    public static void LoadScene(int _buildIndex, float _faderDuration, float _transitionWaitTime)
    {
        Instance.StartCoroutine(Instance.FadeScene(_buildIndex, _faderDuration, _transitionWaitTime));
    }

    private IEnumerator FadeScene(int _buildIndex, float _faderDuration, float _transitionWaitTime)
    {
        _blackImageFader.gameObject.SetActive(true);
        _sceneFader.transform.SetParent(Instance.GetComponent<Transform>());

        for (float t = 0; t < 1; t += Time.deltaTime / _faderDuration)
        {
            _blackImageFader.color = new Color(0, 0, 0, Mathf.Lerp(0, 1, t));
            yield return null;
        }

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(_buildIndex);
        while (!asyncOperation.isDone)
            yield return null;

        CanvasInitialization();
        yield return new WaitForSeconds(_transitionWaitTime);

        for (float t = 0; t < 1; t += Time.deltaTime / 0.5f)
        {
            _blackImageFader.color = new Color(0, 0, 0, Mathf.Lerp(1, 0, t));
            yield return null;
        }

        _blackImageFader.gameObject.SetActive(false);
    }

    private void CanvasInitialization()
    {
        GameObject _mainCameraRef = GameObject.FindWithTag("MainCamera");
        _sceneFader.worldCamera = _mainCameraRef.GetComponent<Camera>();
        _sceneFader.transform.SetParent(_mainCameraRef.GetComponent<Transform>());
        _sceneFader.transform.position = _sceneFader.transform.parent.position;
        _sceneFader.transform.localRotation = Quaternion.identity;
        _sceneFader.transform.position += _smallForward;
        _blackImageFader.rectTransform.sizeDelta = new Vector2(Screen.width + 20, Screen.height + 20);
    }
}