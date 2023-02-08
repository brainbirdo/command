using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesBehaviour : EnviroBehav
{
    public override void Behaviour(GameObject unit)
    {
        SoldierMovement soldierMovement = unit.GetComponent<SoldierMovement>();

        soldierMovement.touchTrees = true;

        soldierMovement.soldierAttack = 5f;
        soldierMovement.soldierSignal = 1f;
        soldierMovement.soldierSpeed = 0.75f;
    }

}
