using UnityEngine;

public class Finishsound : MonoBehaviour
{
    [SerializeField] private AudioClip finishClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            AudioSource.PlayClipAtPoint(finishClip, transform.position);
    }
}