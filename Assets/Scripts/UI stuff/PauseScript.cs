using UnityEngine;

public class PauseScript : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0; // Pause the game
            }
            else
            {
                Time.timeScale = 1; // Resume the game
            }
        }
    }
}
