using System.Collections.Generic;
using UnityEngine;

public class ObjectiveBehaviour : MonoBehaviour
{
    public CircleCollider2D objectiveCollider; // The collider attached to the objective
    public List<GameObject> soldiers = new List<GameObject>(); // List of all soldiers
    public int aliveSoldiers = 0; // Number of alive soldiers that have reached the objective
    public bool allSoldiersReached = false; // True if all alive soldiers have reached the objective
    public GameObject objective1;
    public GameObject objective2;
    public GameObject objective3;
    public GameObject objective4;
    public int objectiveNumber;
    public bool ObjectivesComplete;
    public GameObject blackoutOne;
    public GameObject blackoutTwo;

    void Start()
    {
        // Find the circle collider attached to the objective
        objectiveCollider = objective1.GetComponent<CircleCollider2D>();

        // Find all soldiers in the scene and add them to the list
        foreach (GameObject soldier in GameObject.FindGameObjectsWithTag("Player"))
        {
            soldiers.Add(soldier);
        }
    }

    void Update()
    {
        // Count the number of alive soldiers that have reached the objective
        aliveSoldiers = 0;
        foreach (GameObject soldier in soldiers)
        {
            if (!soldier.GetComponent<SoldierMovement>().isDead && objectiveCollider.OverlapPoint(soldier.transform.position))
            {
                aliveSoldiers++;
            }
        }

        // Check if all alive soldiers have reached the objective
        int aliveSoldiersCount = 0;
        foreach (GameObject soldier in soldiers)
        {
            if (!soldier.GetComponent<SoldierMovement>().isDead)
            {
                aliveSoldiersCount++;
            }
        }

        if (aliveSoldiers == aliveSoldiersCount)
        {
            allSoldiersReached = true;
            ObjMove();
        }
        else
        {
            allSoldiersReached = false;
        }
    }


    public bool AllSoldiersReached()
    {
        return allSoldiersReached;
    }

    public void ObjMove()
    {
        if(allSoldiersReached && !ObjectivesComplete)
        {
            allSoldiersReached = false;
            objectiveNumber += 1;
        }

        if(objectiveNumber == 1)
        {
            objective1.SetActive(false);
            objective2.SetActive(true);
            objectiveCollider = objective2.GetComponent<CircleCollider2D>();
        }

        if (objectiveNumber == 2)
        {
            objective2.SetActive(false);
            objective3.SetActive(true);
            objectiveCollider = objective3.GetComponent<CircleCollider2D>();
            blackoutOne.SetActive(false);
        }

        if (objectiveNumber == 3)
        {
            objective3.SetActive(false);
            objective4.SetActive(true);
            objectiveCollider = objective4.GetComponent<CircleCollider2D>();
            blackoutTwo.SetActive(false);
        }

        if (objectiveNumber == 4)
        {
            objective4.SetActive(false);
            ObjectivesComplete = true;
        }
    }
}
