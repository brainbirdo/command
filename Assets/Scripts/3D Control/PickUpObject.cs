using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public Camera mainCamera; // Reference to the main camera in the scene

    private Vector3 defaultPosition;
    private bool isDragging = false;
    private float myFloat = 0.75f;

    void Start()
    {
        // Store the default position of the object
        defaultPosition = transform.position;

        // If no main camera was set, use the Camera.main property
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void OnMouseDown()
    {
        // Set the dragging flag to true
        isDragging = true;
    }

    void OnMouseUp()
    {
        // Set the dragging flag to false
        isDragging = false;

        // Reset the position of the object to its default position
        transform.position = defaultPosition;

        transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    void Update()
    {
        // Check if the left mouse button is held down and if the object is being dragged
        if (Input.GetMouseButton(0) && isDragging)
        {
            // Move the object in front of the specified camera
            transform.position = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, myFloat));
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
