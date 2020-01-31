using UnityEngine;

public class RedButtonController : MonoBehaviour
{
    private Animator _buttonPressed;
    private SceneController _sceneController;

    private void Start()
    {
        _buttonPressed = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _buttonPressed.enabled = true;

            SceneController.LoadScene();
        }
    }
}
