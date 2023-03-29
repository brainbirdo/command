using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralGroundBehaviour : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SoldierMovement soldierMovement = other.gameObject.GetComponent<SoldierMovement>();

            soldierMovement.touchNeutralGround = true;

            soldierMovement.touchTrees = false;
            soldierMovement.touchWater = false;
            soldierMovement.touchMountains = false;
            soldierMovement.touchSandHills = false;

            soldierMovement.soldierAttack = 5f;
            soldierMovement.soldierSignal = 3f;
            soldierMovement.soldierSpeed = 1f;
        }
    }
}
