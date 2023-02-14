using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 2f;
    public float chaseSpeed = 4f;
    public float chaseRange = 5f;
    public Transform target;

    private int currentWaypointIndex = 0;
    private bool isChasing = false;

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
            else if (target != null && Vector2.Distance(transform.position, target.position) <= chaseRange)
            {
                isChasing = true;
            }
        }
    }

    void SetNextWaypoint()
    {
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform == target)
        {
            isChasing = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform == target)
        {
            isChasing = false;
            SetNextWaypoint();
        }
    }
}
