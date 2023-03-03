using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommsSwitcher : MonoBehaviour
{
    public bool isListening;

    public CaptainAudioController captainAudioController;
    public HellerAudioController hellerAudioController;
    public HelprinAudioController helprinAudioController;

    void Update()
    {
        Voice001();
        Voice002();
        Voice004();
    }

    public void Voice001()
    {
        if (!isListening)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("001");
                isListening = true;
                captainAudioController.isListening = true;
            }
        }

        if (isListening)
        {
            if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                Debug.Log("001 Over");
                isListening = false;
                captainAudioController.isListening = false;
            }
        }
    }

    public void Voice002()
    {
        if (!isListening)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("002");
                isListening = true;
                hellerAudioController.isListening = true;
            }
        }

        if (isListening)
        {
            if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                Debug.Log("002 Over");
                isListening = false;
                hellerAudioController.isListening = false;
            }
        }
    }

    public void Voice004()
    {
        if (!isListening)
        {
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Debug.Log("004");
                isListening = true;
                helprinAudioController.isListening = true;
            }
        }

        if (isListening)
        {
            if (Input.GetKeyUp(KeyCode.Alpha4))
            {
                Debug.Log("004 Over");
                isListening = false;
                helprinAudioController.isListening = false;
            }
        }
    }
}
