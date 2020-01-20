using UnityEngine;

public class ButtonPressed : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Animator>().enabled = true;
            gameManager.BackToMainMenu();
        }
    }
}
