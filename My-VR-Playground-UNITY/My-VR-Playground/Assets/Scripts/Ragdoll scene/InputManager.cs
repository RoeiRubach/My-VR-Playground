using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    [SerializeField] OVRInput.Button _restartButton;

    private void Update()
    {
        if (OVRInput.GetDown(_restartButton))
        {
            SceneManager.LoadScene("Ragdoll");
        }
    }
}
