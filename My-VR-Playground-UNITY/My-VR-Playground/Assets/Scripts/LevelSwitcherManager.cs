using UnityEngine;
using UnityEngine.SceneManagement;

public enum LevelIndex
{
    GrabLevel = 1,
    DistanceGrabLevel,
    GunNBowLevel,
    RagdollNHaptic,
}

public class LevelSwitcherManager : MonoBehaviour
{
    [SerializeField] private LevelIndex levelIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (levelIndex)
            {
                case LevelIndex.GrabLevel:
                    print("Entering Grab level");
                    SetLevelTriggersOff(other);
                    SceneController.LoadScene((int)LevelIndex.GrabLevel, 1f, 1f);
                    break;

                case LevelIndex.DistanceGrabLevel:
                    print("Entering DistanceGrab level");
                    SetLevelTriggersOff(other);
                    SceneController.LoadScene((int)LevelIndex.DistanceGrabLevel, 1f, 1f);
                    break;

                case LevelIndex.GunNBowLevel:
                    print("Entering Gun level");
                    SetLevelTriggersOff(other);
                    SceneController.LoadScene((int)LevelIndex.GunNBowLevel, 1f, 1f);
                    break;

                case LevelIndex.RagdollNHaptic:
                    print("Entering Ragdoll level");
                    SetLevelTriggersOff(other);
                    SceneController.LoadScene((int)LevelIndex.RagdollNHaptic, 1f, 1f);
                    break;

                default:
                    break;
            }
        }
    }

    private void SetLevelTriggersOff(Collider other)
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
}
