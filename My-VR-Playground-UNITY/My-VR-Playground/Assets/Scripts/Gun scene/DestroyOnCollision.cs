using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private float counter = 10f;
    private TargetsController _targetsController;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            Destroy(gameObject);
        
        else if (collision.gameObject.CompareTag("Target"))
        {
            _targetsController = collision.gameObject.GetComponentInParent<TargetsController>();
            _targetsController.DecreaseTargetsCount();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else
            Destroy(gameObject);
    }
}
