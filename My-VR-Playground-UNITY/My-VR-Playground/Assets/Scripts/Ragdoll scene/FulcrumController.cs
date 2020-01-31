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
        OVRInput.SetControllerVibration(0.3f, 0.3f);
        _isFulcrumMoved = true;
        yield return new WaitForSeconds(1f);
        transform.rotation = _startingRotation;
        _isFulcrumMoved = false;
    }
}
