using UnityEngine;

public class BallCollisionManager : MonoBehaviour
{
    private string _ballUpperLimit = "Ball upper limit";
    private AudioSource audioSourceBell;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == _ballUpperLimit)
        {
            audioSourceBell = other.transform.GetComponent<AudioSource>();
            audioSourceBell.Play();
            RagdollManager.Instance.SetRagdollON();
        }
    }
}
