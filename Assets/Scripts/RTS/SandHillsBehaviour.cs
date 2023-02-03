using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandHillsBehaviour : EnviroBehav
{

    public override void Behaviour(GameObject unit)
    {
        SoldierMovement soldierMovement = unit.GetComponent<SoldierMovement>();
        touchSandHills = true;
        soldierMovement.soldierSpeed = 0.75f;
        soldierMovement.soldierSignal = 4f;
    }

}
