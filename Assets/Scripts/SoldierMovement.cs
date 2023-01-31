using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.AI;

public class SoldierMovement : MonoBehaviour
{
    [Header("Soldier Attributes")]
    public float soldierHealth = 100f; // HP
    public float soldierAttack = 5f; // Attack power
    public float soldierSignal = 5f; // Signal strength for comms
    public float soldierSpeed = 1f; // Movement speed
    public bool seenByEnemy = false; // If the soldier has been spotted and is being targeted by Enemy.

    [Header("Pathfinding")]
    public GameObject target;
    Collider2D coll;
    NavMeshAgent agent;
    public bool hasTarget = true;
    public Camera cam;

    [Header("Selection Sprites")]
    public bool isSelected;
    private SpriteRenderer spriteRenderer;
    public Sprite selectedSprite;
    public Sprite unselectedSprite;

    // Add trigger collider to target. When in target's collider, 

    void Start()
    {
        //DO NOT REMOVE
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        ////END
    }


    void Update()
    {

        agent.speed = soldierSpeed;

        if (hasTarget)
        {
            // Sets and displays Target
            agent.SetDestination(target.transform.position);
            target.SetActive(true);
        }
        if (!hasTarget)
        {
            // Hides Target when there is none
            target.SetActive(false);
        }

        SoldierSelection();

        if (isSelected)
        {
            TargetSetting();
        }
    }


    private void SoldierSelection()
    {
        // Selects a soldier if clicked, deselects if right clicked
        if (Input.GetMouseButtonDown(0))
        {
            coll = Physics2D.OverlapPoint(cam.ScreenToWorldPoint(Input.mousePosition));
            if (coll != null)
            {
                isSelected = (coll.gameObject == gameObject);
            }
        }

        if (Input.GetMouseButtonDown(1) && isSelected) 
        {
            isSelected = false;
        }

        if (isSelected)
        {
            spriteRenderer.sprite = selectedSprite;
        }

        if (!isSelected)
        {
            spriteRenderer.sprite = unselectedSprite;
        }
    }


    private void TargetSetting()
    {
        //Sets a Target for the Soldier to move to
        if (isSelected && Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = cam.ScreenToWorldPoint(mousePos);
            mousePos.z = 0;
            target.transform.position = mousePos;
            hasTarget = true;
            target.SetActive(true);
        }
    }
}
