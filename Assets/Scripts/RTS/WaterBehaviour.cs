using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviour : EnviroBehav
{
    public override void Behaviour(GameObject unit)
    {
        SoldierMovement soldierMovement = unit.GetComponent<SoldierMovement>();
        soldierMovement.touchWater = true;
        soldierMovement.soldierSpeed = 0.25f;
        soldierMovement.soldierSignal = 2f;

    }
}
