using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject blackScreenController;

    [SerializeField]
    private Transform targetsParent;

    private List<Transform> targets;

    private void Awake()
    {
        if (blackScreenController != null)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            blackScreenController = GameObject.FindGameObjectWithTag("Canvas");
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }

    private void Start()
    {
        if (targetsParent != null)
        {
            targets = new List<Transform>();
            for (int i = 0; i < targetsParent.childCount; i++)
            {
                for (int j = 0; j < targetsParent.GetChild(i).childCount; j++)
                {
                    targets.Add(targetsParent);
                }
            }
            Debug.Log("list count after START: " + targets.Count);
        }
    }

    private void Update()
    {
        if (SceneManager.sceneCountInBuildSettings > 1)
        {
            if (targetsParent != null)
            {
                if (targets.Count <= 0)
                {
                    BackToMainMenu();
                }
            }
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (blackScreenController == null)
        {
            blackScreenController = GameObject.FindGameObjectWithTag("Canvas");
            Debug.Log("OnSceneLoaded: " + scene.name);
            Debug.Log(mode);
            blackScreenController.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
            blackScreenController.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void BackToMainMenu()
    {
        blackScreenController.transform.GetChild(1).gameObject.SetActive(true);
        Invoke("SwitchToMainMenu", 1.2f);
    }

    private void SwitchToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExtractFromList()
    {
        Debug.Log("List count: "+ targets.Count);
        targets.Remove(targets[0]);
        Debug.Log("List count: " + targets.Count);
    }
}
