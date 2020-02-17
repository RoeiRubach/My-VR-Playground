using System.Collections;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [Header("Assets")]
    [SerializeField] private GameObject _arrowPrefab;

    [Header("Bow")]
    [SerializeField] private float _grabThreshold = 0.15f;
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;
    [SerializeField] private Transform _socket;

    private Transform _pullingHand;
    private Arrow _currentArrow;
    private Animator _animator;

    private float _pullValue;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(CreateArrow(0));
    }

    private void Update()
    {
        if (!_pullingHand || !_currentArrow)
            return;

        _pullValue = CalculatePull(_pullingHand);
        _pullValue = Mathf.Clamp(_pullValue, 0, 1);

        _animator.SetFloat("Blend", _pullValue);
    }

    private float CalculatePull(Transform _pullHand)
    {
        Vector3 direction = _end.position - _start.position;
        float magnitude = direction.magnitude;

        direction.Normalize();
        Vector3 difference = _pullHand.position - _start.position;

        return Vector3.Dot(difference, direction) / magnitude;
    }

    private IEnumerator CreateArrow(float _waitTime)
    {
        // Wait
        yield return new WaitForSeconds(_waitTime);

        // Create, child
        GameObject _arrowObject = Instantiate(_arrowPrefab, _socket);

        // Orient
        _arrowObject.transform.localPosition = new Vector3(0, 0, 0.4225f);
        _arrowObject.transform.localEulerAngles = Vector3.zero;

        // Set
        _currentArrow = _arrowObject.GetComponent<Arrow>();
    }

    public void Pull(Transform _hand)
    {
        float distance = Vector3.Distance(_hand.position, _start.position);
        
        if (distance > _grabThreshold)
            return;

        _pullingHand = _hand;
    }

    public void Release()
    {
        if (_pullValue > 0.25f)
            FireArrow();

        _pullingHand = null;

        _pullValue = 0f;
        _animator.SetFloat("Blend", 0);

        if (!_currentArrow)
            StartCoroutine(CreateArrow(0.25f));
    }

    private void FireArrow()
    {
        _currentArrow.Fire(_pullValue);
        _currentArrow = null;
    }
}
