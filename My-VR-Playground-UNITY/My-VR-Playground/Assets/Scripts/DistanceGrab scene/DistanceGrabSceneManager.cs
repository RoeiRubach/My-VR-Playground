using UnityEngine;

public class DistanceGrabSceneManager : Singleton<DistanceGrabSceneManager>
{
    [SerializeField] Transform _basketsParent;

    private int _basketsCount, _basketsRegistered;

    private void Start()
    {
        Transform[] _basketsParentChildren = _basketsParent.GetComponentsInChildren<Transform>();

        foreach (var item in _basketsParentChildren)
        {
            if (item.GetComponent<BasketManager>())
                _basketsCount++;
        }
    }

    public void IsBasketOrganizationOver()
    {
        if(_basketsCount == _basketsRegistered)
            SceneController.LoadScene();
    }

    public void RegisterBasket()
    {
        _basketsRegistered++;
    }
}