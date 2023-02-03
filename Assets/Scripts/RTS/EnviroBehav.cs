using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroBehav : MonoBehaviour
{
    public SoldierMovement soldierMovement;
    public GameObject soldier;

    [Header("Environment Checks")]
    public bool touchWater;
    public bool touchTrees;
    public bool touchSandHills;
    public bool touchMountains;

    bool overlapped;

    public void EnvironmentChecks()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        Behaviour();
    }

    private void OnTriggerExit(Collider other)
    {
    }


    public virtual void Behaviour()
    {

    }

}
