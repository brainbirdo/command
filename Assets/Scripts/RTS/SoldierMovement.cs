using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SoldierMovement : MonoBehaviour
{
    [Header("Soldier Stats")]
    public float soldierHealth = 100f; // HP
    public float soldierAttack = 5f;
    public float soldierSignal = 3f; // Signal strength for comms
    public float soldierSpeed = 1f; // Movement speed
    public float attackRange = 5f;
    public bool isDead;
    public bool isAlive;
    public bool inCombat;
    public SoldierHealth soldierHealthManager;
    public WeatherController weatherController;
    public bool signalChanged;
    public bool stormSignalChanged;
    public bool rainSignalChanged;
    public bool clearSignalChanged;

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

    public CaptainAudioController captainAudio;
    public HelprinAudioController helprinAudio;
    public HellerAudioController hellerAudio;

    void Start()
    {
        //DO NOT REMOVE OR IT WILL BREAK NAVMESH
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        isAlive = true;
        //END
    }


    void Update()
    {
        if (soldierHealth < 0)
        {
            isDead = true;
            isAlive = false;
        }
        

        agent.speed = soldierSpeed;

        if (hasTarget && transform.position == target.transform.position)
        {
            // If the unit has reached its target, hide the target object
            target.SetActive(false);
            hasTarget = false;
            Debug.Log("Target Hidden");
        }


        SoldierSelection();
        WeatherChecks();

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
            Enemy enemy = other.GetComponentInParent<Enemy>();
            enemy.TakeDamage(soldierAttack);
            inCombat = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            inCombat = false;
            captainAudio.combatAlertGiven = false;
            helprinAudio.combatAlertGiven = false;
            hellerAudio.combatAlertGiven = false;
        }
    }

    private void WeatherChecks()
    {
        if (weatherController.isRainy && !rainSignalChanged)
        {
            stormSignalChanged = false;
            clearSignalChanged = false;

            if(soldierSignal == 3f)
            {
                soldierSignal -= 1f;
                rainSignalChanged = true;
            }
        }
        else if (weatherController.isStormy && !stormSignalChanged)
        {
            rainSignalChanged = false;
            clearSignalChanged = false;

            if (soldierSignal  == 3f)
            {
                soldierSignal -= 1f;
                stormSignalChanged = true;
            }
        }
        else if (weatherController.isClear && !clearSignalChanged)
        {
            stormSignalChanged = false;
            rainSignalChanged = false;
            if (soldierSignal < 3f)
            {
                soldierSignal += 1f;
                clearSignalChanged = true;
            }
        }

    }
}
