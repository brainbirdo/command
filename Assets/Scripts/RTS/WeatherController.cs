using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    private System.Random random;

    public bool isClear;
    public bool isRainy;
    public bool isStormy;

    public HellerAudioController hellerController;
    public HelprinAudioController helprinController;
    public CaptainAudioController captainController;

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
                ClearSkies();
                break;
            case 1:
                RainOn();
                break;
            case 2:
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
    }

    void RainOn()
    {
        isRainy = true;
        isClear = false;
        isStormy = false;
        hellerController.stormAlertGiven = false;
    }

    void StormOn()
    {
        isStormy = true;
        isClear = false;
        isRainy = false;
        hellerController.rainAlertGiven = false;
    }
}
