using UnityEngine;

public class GrabLevelManager : MonoBehaviour
{
    [SerializeField] private Transform cubesParent;

    private Transform[] cubesArray;

    private void Start()
    {
        cubesArray = cubesParent.GetComponentsInChildren<Transform>();

        int randomNum = Random.Range(0, cubesArray.Length + 1);

        cubesArray[randomNum].tag = "Player";
    }
}