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
        if (soldierMovement.soldierHealth <= 90)
        {

        }
        if (soldierMovement.soldierHealth <= 80)
        {

        }
        if (soldierMovement.soldierHealth <= 70)
        {

        }
        if (soldierMovement.soldierHealth <= 60)
        {

        }
        if (soldierMovement.soldierHealth <= 50)
        {

        }
        if (soldierMovement.soldierHealth <= 40)
        {

        }
        if (soldierMovement.soldierHealth <= 30)
        {

        }
        if (soldierMovement.soldierHealth <= 20)
        {

        }
        if (soldierMovement.soldierHealth <= 10)
        {

        }
    }
}
