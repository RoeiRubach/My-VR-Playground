using UnityEngine;

public class OnDestroyGameObject : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    private void OnDestroy()
    {
        gameManager.ExtractFromList();
    }
}
