using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sensitivity = 100f;
    public float smoothing = 2f;
    public float minPitch = -80f;
    public float maxPitch = 80f;
    public float minYaw = -180f;
    public float maxYaw = 180f;

    Vector2 mouseLook;
    Vector2 smoothV;

    void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;

        // Clamp pitch
        mouseLook.y = Mathf.Clamp(mouseLook.y, minPitch, maxPitch);

        // Clamp yaw
        mouseLook.x = Mathf.Clamp(mouseLook.x, minYaw, maxYaw);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        transform.localRotation *= Quaternion.AngleAxis(mouseLook.x, Vector3.up);
    }
}
