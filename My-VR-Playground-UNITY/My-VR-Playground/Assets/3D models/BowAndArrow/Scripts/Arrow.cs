using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float _speed = 2000f;
    [SerializeField] private Transform _tip;

    private Rigidbody _rigidBody;
    private bool _isStopped = true;
    private Vector3 _lastPosition;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_isStopped)
            return;
        
        _rigidBody.MoveRotation(Quaternion.LookRotation(_rigidBody.velocity, transform.up));

        //if (Physics.Linecast(_lastPosition, _tip.position))
        //    Stop();

        _lastPosition = _tip.position;
    }

    private void Stop()
    {
        _isStopped = true;

        _rigidBody.isKinematic = true;
        _rigidBody.useGravity = false;
    }

    public void Fire(float _pullValue)
    {
        _isStopped = false;

        transform.parent = null;
        _rigidBody.isKinematic = false;
        _rigidBody.useGravity = true;
        _rigidBody.AddForce(transform.forward * (_pullValue * _speed));

        Destroy(gameObject, 5f);
    }
}
