using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandHillsBehaviour : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SoldierMovement soldierMovement = other.gameObject.GetComponent<SoldierMovement>();

            soldierMovement.touchSandHills = true;

            soldierMovement.touchTrees = false;
            soldierMovement.touchWater = false;
            soldierMovement.touchMountains = false;
            soldierMovement.touchNeutralGround = false;

            soldierMovement.soldierAttack = 5f;
            soldierMovement.soldierSignal = 3f;
            soldierMovement.soldierSpeed = 0.75f;
        }
            
    }

}
