using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    // Follow the waypoints to walk from one to another
    [SerializeField]
    private Transform[] waypoints;

    // Enemy walk speed
    [SerializeField]
    private float moveSpeed = 2f;

    // The current waypoint from which the enemy walks from 
    private int waypointIndex = 0;

    // Inizilation 
    private void Start()
    {
        //Set the postion of the enemy and the postion of the first waypoint 
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        // Move the enemy 
        Move();
    }

    //Make the enemy walk
    private void Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            // Move the enemy from the current waypoint to the next

            transform.position = Vector3.MoveTowards(transform.position,
                                         waypoints[waypointIndex].transform.position,
                                         moveSpeed * Time.deltaTime);   
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out WayPointID waypointID))
        {
            if (waypointID.ID == waypointIndex)
            {
                waypointIndex++;
            }
        }
    }

}
