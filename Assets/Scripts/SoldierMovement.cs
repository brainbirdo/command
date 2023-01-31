using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.AI;

public class SoldierMovement : MonoBehaviour
{
    [Header("Pathfinding")]
    [SerializeField] GameObject target;
    NavMeshAgent agent;
    [SerializeField] private bool hasTarget = true;
    public Camera cam;
    public CircleCollider2D coll;

    [Header("Selection Sprites")]
    [SerializeField] private bool isSelected;
    private SpriteRenderer spriteRenderer;
    public Sprite selectedSprite;
    public Sprite unselectedSprite;


    void Start()
    {
        //DO NOT REMOVE
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        ////END
    }

    // Issues:
    // - It will move upon selection to wherever you selected.
    // - It will move anywhere rather than along a grid.

    void Update()
    {
        if (hasTarget)
        {
            // Sets and displays Target
            agent.SetDestination(target.transform.position);
            target.SetActive(true);
        }
        if (!hasTarget)
        {
            // Hides Target when there is none
            target.SetActive(true);
        }

        SoldierSelection();

        if (isSelected)
        {
            TargetSetting();
        }
    }


    private void SoldierSelection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D hit = Physics2D.OverlapPoint(cam.ScreenToWorldPoint(Input.mousePosition));
            if (hit != null && hit.GetComponent<CircleCollider2D>() != null)
            {
                isSelected = true;
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
        if (Input.GetMouseButtonDown(0))
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
