using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    private System.Random random;

    public bool isClear;
    public bool isRainy;
    public bool isStormy;

    public CommsSwitcher commsSwitcher;
    public HellerAudioController hellerController;
    public HelprinAudioController helprinController;
    public CaptainAudioController captainController;

    public AudioSource rainAudio;
    public AudioSource stormAudio;

    void Start()
    {
        ClearSkies();

        random = new System.Random();
        InvokeRepeating("GenerateRandomNumber", 35, 35);
    }

    void GenerateRandomNumber()
    {
        // Generate a random number between 0 and 2.
        int randomNumber = random.Next(0, 3);

        // Invoke a different method based on the random number.
        switch (randomNumber)
        {
            case 0:
                Debug.Log("Clear");
                ClearSkies();
                break;
            case 1:
                Debug.Log("Rain");
                RainOn();
                break;
            case 2:
                Debug.Log("Storm");
                StormOn();
                break;
        }
    }

    void ClearSkies()
    {
        isClear = true;
        isRainy = false;
        isStormy = false;
        hellerController.rainAlertGiven = false;
        hellerController.stormAlertGiven = false;
        helprinController.rainAlertGiven = false;
        helprinController.stormAlertGiven = false;
        stormAudio.volume = 0.0f;
        rainAudio.volume = 0.0f;
    }

    void RainOn()
    {
        isRainy = true;
        isClear = false;
        isStormy = false;
        hellerController.stormAlertGiven = false;
        helprinController.stormAlertGiven = false;
        if (commsSwitcher.isListening)
        {
            stormAudio.volume = 0.0f;
            rainAudio.volume = 0.8f;
        }
        if (!commsSwitcher.isListening)
        {
            stormAudio.volume = 0.0f;
            rainAudio.volume = 0.0f;
        }
    }

    void StormOn()
    {
        isStormy = true;
        isClear = false;
        isRainy = false;
        hellerController.rainAlertGiven = false;
        helprinController.rainAlertGiven = false;

        if (commsSwitcher.isListening)
        {
            stormAudio.volume = 0.4f;
            rainAudio.volume = 0.0f;
        }
        if (!commsSwitcher.isListening)
        {
            stormAudio.volume = 0.0f;
            rainAudio.volume = 0.0f;
        }

    }
}
