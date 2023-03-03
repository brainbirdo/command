using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierHealth : MonoBehaviour
{
    public SoldierMovement soldierMovement;
    public GameObject soldierUnit;

    public GameObject[] healthBar;

    private void Update()
    {
        if (soldierMovement.soldierHealth < 0)
        {
            soldierUnit.SetActive(false);
        }
        else
        {
            HealthBar();
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
}
