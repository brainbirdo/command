using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviour : EnviroBehav
{
    public override void Behaviour(GameObject unit)
    {
        SoldierMovement soldierMovement = unit.GetComponent<SoldierMovement>();

        soldierMovement.touchWater = true;

        soldierMovement.touchTrees = false;
        soldierMovement.touchNeutralGround = false;
        soldierMovement.touchMountains = false;
        soldierMovement.touchSandHills = false;

        soldierMovement.soldierAttack = 5f;
        soldierMovement.soldierSignal = 2f;
        soldierMovement.soldierSpeed = 0.25f;

    }
}
