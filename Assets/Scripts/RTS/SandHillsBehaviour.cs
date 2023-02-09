using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandHillsBehaviour : EnviroBehav
{

    public override void Behaviour(GameObject unit)
    {
        SoldierMovement soldierMovement = unit.GetComponent<SoldierMovement>();

        soldierMovement.touchSandHills = true;

        soldierMovement.touchTrees = false;
        soldierMovement.touchWater = false;
        soldierMovement.touchMountains= false;
        soldierMovement.touchNeutralGround = false;

        soldierMovement.soldierAttack = 5f;
        soldierMovement.soldierSignal = 4f;
        soldierMovement.soldierSpeed = 0.75f;
    }

}
