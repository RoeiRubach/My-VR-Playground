﻿using UnityEngine;
using System.Collections.Generic;

public class BasketManager : MonoBehaviour
{
    [SerializeField] private Renderer _basketRefMat;

    [SerializeField] private string _tagToCompare;

    [SerializeField] private Transform _itemsParentRef;

    private Transform[] _childrenArray;

    private List<Transform> _itemsCounterList = new List<Transform>();

    private int _itemsRegisterCounter;

    private void Start()
    {
        _childrenArray = _itemsParentRef.GetComponentsInChildren<Transform>();

        foreach (var item in _childrenArray)
        {
            if (item.gameObject.CompareTag(_tagToCompare))
                _itemsCounterList.Add(item);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_tagToCompare))
        {
            Destroy(other.gameObject);
            _itemsRegisterCounter++;

            if (_itemsRegisterCounter == _itemsCounterList.Count)
            {
                _basketRefMat.material.color = Color.green;
                DistanceGrabSceneManager.Instance.RegisterBasket();

                DistanceGrabSceneManager.Instance.IsBasketOrganizationOver();
            }
        }
        else
        {
            if (!other.name.Equals("GrabVolumeCone"))
            {
                _basketRefMat.GetComponent<MeshCollider>().enabled = false;

                if (other.GetComponent<Rigidbody>())
                    other.GetComponent<Rigidbody>().AddExplosionForce(90f, (other.transform.position - other.transform.right * 0.3f - other.transform.up * 0.6f), 1f);

                _basketRefMat.material.color = Color.red;
                Invoke("MaterialBackToWhite", 1f);
            }
        }
    }

    private void MaterialBackToWhite()
    {
        _basketRefMat.GetComponent<MeshCollider>().enabled = true;
        _basketRefMat.material.color = Color.white;
    }
}
