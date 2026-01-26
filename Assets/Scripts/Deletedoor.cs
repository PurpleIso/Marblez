using UnityEngine;

public class Deletedoor : MonoBehaviour
{

    //destroys walls when the f key is pressed
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Destroy(gameObject);
        }
    }
}