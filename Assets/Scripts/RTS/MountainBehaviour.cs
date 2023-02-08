using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainBehaviour : EnviroBehav
{
    public override void Behaviour(GameObject unit)
    {
        SoldierMovement soldierMovement = unit.GetComponent<SoldierMovement>();

        soldierMovement.touchMountains = true;

        soldierMovement.soldierAttack = 5f;
        soldierMovement.soldierSignal = 4f;
        soldierMovement.soldierSpeed = 0.5f;
    }

}
