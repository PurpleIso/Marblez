using UnityEngine;

public class OpenCloseGate : MonoBehaviour
{
    private bool isVisible = true;
    void Start()
    {
        gameObject.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isVisible = !isVisible;
            gameObject.SetActive(isVisible);
        }
    }
}
