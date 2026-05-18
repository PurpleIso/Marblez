using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Backtomainmenu : MonoBehaviour
{
        public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Console.WriteLine("shit works");
    }
}
