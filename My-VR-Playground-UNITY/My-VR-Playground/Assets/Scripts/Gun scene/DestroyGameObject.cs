using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    private void Start()
    {
        if (!transform.CompareTag("Bullet"))
            Destroy(gameObject, 1.5f);
        else
            Destroy(gameObject, 7f);
    }
}
