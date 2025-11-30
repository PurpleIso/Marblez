using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public DoorScript connectedDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (connectedDoor != null)
            {
                connectedDoor.OpenDoor();
            }
            gameObject.SetActive(false);
        }
    }
}
