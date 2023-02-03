using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesBehaviour : EnviroBehav
{
    public override void Behaviour()
    {
        //if Soldier's Box COllider stays in Treebox
        touchTrees = true;
        soldierMovement.soldierSpeed = 0.75f;
        soldierMovement.soldierSignal = 1f;
    }

}
