using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesBehaviour : EnviroBehav
{
    public override void Behaviour(GameObject unit)
    {
        SoldierMovement soldierMovement = unit.GetComponent<SoldierMovement>();
        //if Soldier's Box COllider stays in Treebox
        soldierMovement.touchTrees = true;
        soldierMovement.soldierSpeed = 0.75f;
        soldierMovement.soldierSignal = 1f;
    }

}
