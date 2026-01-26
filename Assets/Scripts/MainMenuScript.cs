using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    //changes scene to the game
    public void StartGame()
    { 
        SceneManager.LoadScene("SampleScene");
    }

    //quits the game
    public void Quit()
    {
        Debug.Log("pretend it closed game");
        Application.Quit();
    }
}

