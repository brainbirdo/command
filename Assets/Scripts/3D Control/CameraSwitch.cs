using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    public Camera camera3;

    public bool onCameraMain;

    void Start()
    {
        // Enable only the main camera at the beginning
        camera1.enabled = true;
        camera2.enabled = false;
        camera3.enabled = false;
        onCameraMain = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            camera1.enabled = false;
            camera2.enabled = true;
            camera3.enabled = false;
            onCameraMain = false;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            camera1.enabled = false;
            camera2.enabled = false;
            camera3.enabled = true;
            onCameraMain = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            camera1.enabled = true;
            camera2.enabled = false;
            camera3.enabled = false;
            onCameraMain = true;
        }
    }
}
