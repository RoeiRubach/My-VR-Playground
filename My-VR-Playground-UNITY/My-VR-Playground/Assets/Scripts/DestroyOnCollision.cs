using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private float counter = 10f;
    
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.collider.gameObject.name);
        if (collision.collider.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        else if (collision.collider.gameObject.CompareTag("Target"))
        {
            Destroy(collision.collider.gameObject);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        counter -= Time.deltaTime;

        if (!gameObject.CompareTag("Target"))
        {
            if (counter <= 0)
            {
                counter = 10f;
                Destroy(gameObject);
            }
        }
    }
}
