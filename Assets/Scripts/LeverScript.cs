using UnityEngine;
using UnityEngine.Events;

public class LeverScript : MonoBehaviour
{
    // UnityEvent to invoke when the lever is triggered
    public UnityEvent OnLeverTriggered;

    // If the player collides with the lever, invoke the event and disable the lever
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnLeverTriggered.Invoke();
            gameObject.SetActive(false);
        }
    }
}
