using UnityEngine;

public class TargetsController : MonoBehaviour
{
    private int _targetCount;
    private bool _isLevelEnded;
    private Transform[] _targets;

    private void Start()
    {
        _targets = GetComponentsInChildren<Transform>();

        foreach (Transform targets in _targets)
        {
            if (targets.CompareTag("Target"))
            {
                _targetCount++;
            }
        }
    }

    private void LateUpdate()
    {
        if (_targetCount <= 0 && !_isLevelEnded)
        {
            _isLevelEnded = true;
            
            SceneController.LoadScene(0, 1f, 1f);
        }
    }

    public void DecreaseTargetsCount()
    {
        _targetCount--;
    }
}