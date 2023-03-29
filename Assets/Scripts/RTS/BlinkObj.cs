using UnityEngine;
using System.Collections;

public class BlinkObj : MonoBehaviour
{

    public float blinkInterval = 0.5f; // The time interval between blinks
    private Renderer objectRenderer; // The renderer component of the object

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            objectRenderer.enabled = false;
            yield return new WaitForSeconds(blinkInterval);
            objectRenderer.enabled = true;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}