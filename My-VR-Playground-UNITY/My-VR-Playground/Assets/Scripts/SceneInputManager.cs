using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInputManager : MonoBehaviour
{
    [SerializeField] OVRInput.Button _restartButton;
    [SerializeField] OVRInput.Button _mainMenuButton;

    private Scene _currentScene;

    private void Start()
    {
        _currentScene = SceneManager.GetActiveScene();
    }

    private void Update()
    {
        if (OVRInput.GetDown(_restartButton))
            SceneController.LoadScene(_currentScene.buildIndex, 0.2f, 0.5f);

        if (OVRInput.GetDown(_mainMenuButton))
            SceneController.LoadScene();
    }
}
