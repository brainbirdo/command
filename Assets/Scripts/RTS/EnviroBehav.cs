using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroBehav : MonoBehaviour
{
    public SoldierMovement soldierMovement;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<SoldierMovement>())
        {
            Behaviour(other.GetComponent<SoldierMovement>().gameObject);
            Debug.Log("Collision");
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<SoldierMovement>())
        {

        }

    }

    public virtual void Behaviour(GameObject unit)
    {

    }

}