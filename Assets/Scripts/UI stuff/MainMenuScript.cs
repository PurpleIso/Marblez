using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void StartLevel1()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void StartLevel2()
    {
        SceneManager.LoadScene("LVL2");
    }

    public void Quit()
    {
        Debug.Log("quit game");
        Application.Quit();
    }
}