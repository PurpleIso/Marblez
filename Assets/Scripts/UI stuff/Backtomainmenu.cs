        using UnityEngine;
        using UnityEngine.SceneManagement;

        public class Backtomainmenu : MonoBehaviour
        {  
            public void BackToMainMenu()
            {
                SceneManager.LoadScene("MainMenu");
                Debug.Log("BackToMainMenu");
            }
        }
