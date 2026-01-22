using UnityEngine;

public class OpenCloseGate : MonoBehaviour
{
    private bool isVisible = true;
    private Renderer[] renderers;
    private Collider[] colliders;
    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        colliders = GetComponentsInChildren<Collider>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            isVisible = !isVisible;
            foreach (Renderer r in renderers)
                r.enabled = isVisible;
            foreach (Collider c in colliders)
                c.enabled = isVisible;
        }
    }
}