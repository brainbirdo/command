using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SoldierMovement : MonoBehaviour
{
    [Header("Soldier Stats")]
    public float soldierHealth = 100f; // HP
    public float soldierAttack = 5f;
    public float soldierSignal = 5f; // Signal strength for comms
    public float soldierSpeed = 1f; // Movement speed
    public float attackRange = 5f;

    [Header("Pathfinding")]
    public GameObject target;
    [SerializeField] Collider2D coll;
    NavMeshAgent agent;
    public bool hasTarget = true;
    public Camera cam;
    public GameObject targetEnemy;

    [Header("Selection")]
    public bool isSelected;
    private bool isSettingTarget = false;
    private SpriteRenderer spriteRenderer;
    public Sprite selectedSprite;
    public Sprite unselectedSprite;
    public GameObject screenSelection;


    [Header("Environment Checks")]
    public bool touchNeutralGround;
    public bool touchWater;
    public bool touchTrees;
    public bool touchSandHills;
    public bool touchMountains;

    void Start()
    {
        //DO NOT REMOVE OR IT WILL BREAK NAVMESH
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        //END
    }


    void Update()
    {



        agent.speed = soldierSpeed;

        if (hasTarget && transform.position == target.transform.position)
        {
            // If the unit has reached its target, hide the target object
            target.SetActive(false);
            hasTarget = false;
            Debug.Log("Target Hidden");
        }


        SoldierSelection();

        if (isSelected)
        {
            TargetSetting();
            screenSelection.SetActive(true);
        }

        if (!isSelected)
        {
            screenSelection.SetActive(false);
        }
    }


        private void SoldierSelection()
    {
        // Selects a soldier if clicked, deselects if right clicked
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D[] hits = Physics2D.OverlapPointAll(cam.ScreenToWorldPoint(Input.mousePosition));
            foreach (Collider2D hit in hits)
            {
                if (hit.CompareTag("Range") && hit.transform.parent == transform)
                {
                    isSelected = true;
                    break;
                }
            }
        }

        if (Input.GetMouseButtonDown(1) && isSelected)
        {
            isSelected = false;
            isSettingTarget = false; // Set isSettingTarget back to false after the target has been set

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
        if (isSelected && Input.GetMouseButtonDown(0))
        {
            if (!isSettingTarget)
            {
                isSettingTarget = true;
                return; // Exit the method and wait for the next click to set the target
            }

            Vector3 mousePos = Input.mousePosition;
            mousePos = cam.ScreenToWorldPoint(mousePos);
            mousePos.z = -0.5833309f;
            target.transform.position = mousePos;
            hasTarget = true;
            agent.SetDestination(target.transform.position);
            target.SetActive(true);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Should be Taking Damage for enemy");
            Enemy enemy = other.GetComponentInParent<Enemy>();
            enemy.TakeDamage(soldierAttack);
        }
    }
}
