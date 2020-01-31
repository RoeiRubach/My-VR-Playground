using UnityEngine;

public class TargetManager : MonoBehaviour
{
    private string _bulletTag = "Bullet";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_bulletTag))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
