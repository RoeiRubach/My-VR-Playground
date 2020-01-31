using UnityEngine;

public class GunNBowSceneManager : Singleton<GunNBowSceneManager>
{
    [SerializeField] Transform _targetsParent;

    private int _targetsCount, _targetsRegistered;

    private void Start()
    {
        Transform[] _basketsParentChildren = _targetsParent.GetComponentsInChildren<Transform>();

        foreach (var item in _basketsParentChildren)
        {
            if (item.GetComponent<TargetManager>())
                _targetsCount++;
        }
    }

    public void IsAllTargetsDestroyed()
    {
        if (_targetsCount == _targetsRegistered)
            SceneController.LoadScene();
    }

    public void RegisterTargets()
    {
        _targetsRegistered++;
    }
}