using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public CameraSwitch cameraSwitch;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && cameraSwitch.onCameraMain)
        {
            ExittheGame();
        }
    }

    public void ExittheGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

}
