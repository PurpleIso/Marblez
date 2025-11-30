using UnityEngine;

public class DoorScript: MonoBehaviour
{
    public Vector3 openPositionOffset = new Vector3(0, 5f, 0);
    public float openingDuration = 1.0f; 
    private Vector3 closedPosition;
    private bool isOpening = false;
    private float startTime;

    void Start()
    {
        closedPosition = transform.position; 
    }
    public void OpenDoor()
    {
        if (!isOpening)
        {
            isOpening = true;
            startTime = Time.time;
        }
    }

    void Update()
    {
        if (isOpening)
        {
            float t = (Time.time - startTime) / openingDuration;
            transform.position = Vector3.Lerp(closedPosition, closedPosition + openPositionOffset, t);

            if (t >= 1.0f)
            {
                isOpening = false;
                transform.position = closedPosition + openPositionOffset;
            }
        }
    }
}
