using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommsSwitcher : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Debug.Log("001");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("002");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("003");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("004");
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("005");
        }
    }
}
