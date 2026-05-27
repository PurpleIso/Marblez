using UnityEngine;

public class Sound : MonoBehaviour
{

    //plays sound when rigidbody moves
    void Update()
    {
        if (GetComponent<Rigidbody>().linearVelocity.magnitude > 0.1f && !GetComponent<AudioSource>().isPlaying)
            GetComponent<AudioSource>().Play();
    }

}
