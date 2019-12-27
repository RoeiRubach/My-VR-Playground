using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private float counter = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Target"))
        {
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
