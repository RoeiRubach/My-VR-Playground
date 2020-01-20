using System.Collections;
using UnityEngine;

public class FulcrumController : MonoBehaviour
{
    private Quaternion _startingRotation;
    private bool _isFulcrumMoved;

    private void Start()
    {
        _startingRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        if (transform.rotation != _startingRotation && !_isFulcrumMoved)
            StartCoroutine(SetFulcrumBack());
    }

    private IEnumerator SetFulcrumBack()
    {
        print("IEnumerator started");
        _isFulcrumMoved = true;
        yield return new WaitForSeconds(1f);
        transform.rotation = _startingRotation;
        _isFulcrumMoved = false;
    }
}
