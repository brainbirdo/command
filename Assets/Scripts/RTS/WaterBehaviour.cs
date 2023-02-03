using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviour : EnviroBehav
{
    public override void Behaviour()
    {
        //if Soldier's Box COllider stays in Treebox
        touchWater = true;
        soldierMovement.soldierSpeed = 0.25f;
        soldierMovement.soldierSignal = 2f;

    }
}
