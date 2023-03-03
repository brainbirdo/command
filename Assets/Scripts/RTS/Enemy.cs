using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Pathfinding")]
    public Transform[] waypoints;
    public float moveSpeed = 2f;
    public float chaseSpeed = 4f;
    public float chaseRange = 5f;
    public Transform target;

    private int currentWaypointIndex = 0;
    private bool isChasing = false;

    [Header("Stats")]
    public float damagePerSecond = 5f;
    public float enemyHealth = 100f;

    void Start()
    {
        SetNextWaypoint();
    }

    void Update()
    {
        if (isChasing)
        {
            if (target != null && Vector2.Distance(transform.position, target.position) <= chaseRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, chaseSpeed * Time.deltaTime);

                // Check if the target is a Soldier and reduce its health by the damage per second
                SoldierMovement soldier = target.GetComponentInParent<SoldierMovement>();
                if (soldier != null)
                {
                    soldier.soldierHealth -= damagePerSecond * Time.deltaTime;
                }
            }
            else
            {
                isChasing = false;
                SetNextWaypoint();
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
            {
                SetNextWaypoint();
            }
        }
    }

    void SetNextWaypoint()
    {
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.transform.Find("Range");
            isChasing = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform == target)
        {
            target = null;
            isChasing = false;
            SetNextWaypoint();
        }
    }
}
