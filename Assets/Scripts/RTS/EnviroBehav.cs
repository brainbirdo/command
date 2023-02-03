using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroBehav : MonoBehaviour


    bool overlapped;

    public void EnvironmentChecks()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<SoldierMovement>())
        {
            Behaviour(other.GetComponent<SoldierMovement>().gameObject);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
    }


    public virtual void Behaviour(GameObject unit)
    {

    }

}
