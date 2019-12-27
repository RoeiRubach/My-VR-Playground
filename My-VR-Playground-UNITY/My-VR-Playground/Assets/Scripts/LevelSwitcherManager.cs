using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcherManager : MonoBehaviour
{
    [SerializeField]
    private int levelToSwitchTo;

    [SerializeField]
    private Canvas blackscreenCanvas;

    private void OnTriggerEnter(Collider other)
    {
        switch (levelToSwitchTo)
        {
            case 1:
                print("Entering Grab level");
                LevelTriggerManager(other);
                break;

            case 2:
                print("Entering DistanceGrab level");
                LevelTriggerManager(other);
                break;

            case 3:
                print("Entering Gun level");
                LevelTriggerManager(other);
                break;

            case 4:
                print("Entering Ragdoll level");
                LevelTriggerManager(other);
                break;

            default:
                break;
        }
    }

    private void LevelTriggerManager(Collider other)
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        blackscreenCanvas.transform.GetChild(0).gameObject.SetActive(true);
        Invoke("SwitchToLevel", 1.2f);
    }

    private void SwitchToLevel()
    {
        SceneManager.LoadScene(levelToSwitchTo);
    }
}
