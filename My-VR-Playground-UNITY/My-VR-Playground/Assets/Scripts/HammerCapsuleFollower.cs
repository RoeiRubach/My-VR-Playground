using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HammerCapsuleFollower : MonoBehaviour
{
    private HammerCapsule _hammerFollower;
    private Rigidbody _rigidbody;
    private Vector3 _velocity;

    [SerializeField] private float _sensitivity = 80f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 destination = _hammerFollower.transform.position;
        transform.rotation = _hammerFollower.transform.rotation;

        _velocity = (destination - _rigidbody.transform.position) * _sensitivity;
        
        _rigidbody.velocity = _velocity;
    }

    public void SetFollowTarget(HammerCapsule hammerFollower)
    {
        _hammerFollower = hammerFollower;
    }
}
