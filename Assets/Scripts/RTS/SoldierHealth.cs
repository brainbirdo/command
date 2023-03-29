using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierHealth : MonoBehaviour
{
    public SoldierMovement soldierMovement;
    public GameObject soldierUnit;

    public GameObject[] healthBar;
    public GameObject[] signalBar;

    private void Update()
    {
        if (soldierMovement.soldierHealth < 0)
        {
            soldierUnit.SetActive(false);
            soldierMovement.isDead = true;
            soldierMovement.isAlive = false;
        }
        else
        {
            HealthBar();
            SignalBar();
        }
    }

    public void HealthBar()
    {
        for (int i = 0; i < healthBar.Length; i++)
        {
            if ((i + 1) * 10 >= soldierMovement.soldierHealth)
            {
                healthBar[i].SetActive(false);
            }
            else
            {
                healthBar[i].SetActive(true);
            }
        }
    }


    public void SignalBar()
    {
        for (int i = 0; i < signalBar.Length; i++)
        {
            if (i * 1 >= soldierMovement.soldierSignal)
            {
                signalBar[i].SetActive(false);
            }
            else
            {
                signalBar[i].SetActive(true);
            }
        }
    }
}
