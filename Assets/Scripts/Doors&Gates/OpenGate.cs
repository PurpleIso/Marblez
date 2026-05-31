using UnityEngine;

public class OpenCloseGate : MonoBehaviour
{
    private bool isVisible = true;
    private Renderer gateRenderer; // Cache the Renderer component

    void Start()
    {
        gateRenderer = GetComponent<Renderer>();
        gateRenderer.enabled = true; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isVisible = !isVisible;
            gateRenderer.enabled = isVisible; // Toggle visibility
            GetComponent<AudioSource>().Play(); // Play audio
        }
    }
}