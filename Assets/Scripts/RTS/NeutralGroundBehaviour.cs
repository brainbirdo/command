using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralGroundBehaviour : EnviroBehav
{
    public override void Behaviour(GameObject unit)
    {
        SoldierMovement soldierMovement = unit.GetComponent<SoldierMovement>();

        soldierMovement.touchNeutralGround = true;

        soldierMovement.soldierAttack = 5f;
        soldierMovement.soldierSignal = 5f;
        soldierMovement.soldierSpeed = 1f;



        soldierMovement.touchTrees = false;
        soldierMovement.touchWater = false;
        soldierMovement.touchMountains = false;
        soldierMovement.touchSandHills = false;
    }
}
