using UnityEngine;

public class HammerCapsule : MonoBehaviour
{
    [SerializeField] private HammerCapsuleFollower _hammerCapsuleFollower;

    private void Start()
    {
        SpawnHammerCapsuleFollower();
    }

    private void SpawnHammerCapsuleFollower()
    {
        var follower = Instantiate(_hammerCapsuleFollower);
        follower.transform.position = transform.position;
        follower.SetFollowTarget(this);
    }
}
