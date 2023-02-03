using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainBehaviour : EnviroBehav
{
    public override void Behaviour()
    {
        touchMountains = true;
        soldierMovement.soldierSpeed = 0.5f;
        soldierMovement.soldierSignal = 4f;
    }

}
