using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainBehaviour : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SoldierMovement soldierMovement = other.gameObject.GetComponent<SoldierMovement>();

            soldierMovement.touchMountains = true;

            soldierMovement.touchSandHills = false;
            soldierMovement.touchWater = false;
            soldierMovement.touchTrees = false;
            soldierMovement.touchNeutralGround = false;

            soldierMovement.soldierAttack = 5f;
            soldierMovement.soldierSignal = 3f;
            soldierMovement.soldierSpeed = 0.5f;
        }
    }

}
