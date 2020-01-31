using UnityEngine;
using System.Collections.Generic;

public class RagdollManager : Singleton<RagdollManager>
{
    [SerializeField] private List<Rigidbody> _ragdollKinematic = new List<Rigidbody>();

    private void Start()
    {
        SetRagdollOFF();
    }

    private void SetRagdollOFF()
    {
        Rigidbody[] rigidbodies = gameObject.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody c in rigidbodies)
        {
            _ragdollKinematic.Add(c);
            c.isKinematic = true;
        }
    }

    public void SetRagdollON()
    {
        gameObject.GetComponent<Animator>().enabled = false;

        foreach (Rigidbody c in _ragdollKinematic)
        {
            c.isKinematic = false;
        }
    }
}
