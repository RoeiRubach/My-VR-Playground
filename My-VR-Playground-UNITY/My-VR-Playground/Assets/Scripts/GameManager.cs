using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Canvas blackscreenFadeOut;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
        blackscreenFadeOut.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void BackToMainMenu()
    {
        blackscreenFadeOut.transform.GetChild(1).gameObject.SetActive(true);
        Invoke("SwitchToMainMenu", 1.2f);
    }

    private void SwitchToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
