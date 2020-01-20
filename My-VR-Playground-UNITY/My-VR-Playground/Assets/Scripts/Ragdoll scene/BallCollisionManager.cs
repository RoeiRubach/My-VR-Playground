using UnityEngine;

public class BallCollisionManager : MonoBehaviour
{
    private string _ballUpperLimit = "Ball upper limit";
    private AudioSource _audioSourceBell;
    [SerializeField] private AudioSource _maleLaughter;
    private Animator _dummyAnimator;
    private Rigidbody _rigidbody;
    private bool _isBallMoved, _isBallTouchedBell;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _dummyAnimator = _maleLaughter.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (!_isBallMoved)
            _isBallMoved = _rigidbody.velocity != Vector3.zero ? true : false;

        else if(_isBallMoved && !_isBallTouchedBell)
            if (_rigidbody.velocity == Vector3.zero)
            {
                _isBallMoved = false;
                _dummyAnimator.SetBool("didntBallReachBell", true);
                _maleLaughter.Play();
                Invoke("SetAnimatorLaughterBoolFalse", 0.2f);
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == _ballUpperLimit)
        {
            _isBallTouchedBell = true;
            _audioSourceBell = other.transform.GetComponent<AudioSource>();
            _audioSourceBell.Play();
            RagdollManager.Instance.SetRagdollON();
        }
    }

    private void SetAnimatorLaughterBoolFalse()
    {
        _dummyAnimator.SetBool("didntBallReachBell", false);
    }
}
