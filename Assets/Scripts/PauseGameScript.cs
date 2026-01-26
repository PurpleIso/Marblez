using UnityEngine;

public class PauseGameScript : MonoBehaviour
{
    //pauses and unpauses the game when the escape key is pressed
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
        }
    }
}
