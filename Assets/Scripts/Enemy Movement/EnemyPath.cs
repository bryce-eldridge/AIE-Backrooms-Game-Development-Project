using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPath : MonoBehaviour
{
    // Follow the waypoints to walk from one to another
    [SerializeField]
    private Transform[] waypoints;

    // Enemy walk speed
    [SerializeField]
    private float moveSpeed = 2f;

    
    private GameObject Player;

    // The current waypoint from which the enemy walks from 
    private int waypointIndex = 0;

    //AI Pathing

    NavMeshAgent Navigation;

    

    float VisionRadius = 4f;

    bool chasingcharacter = false;

   

    // Inizilation 
    private void Start()
    {
        Navigation = GetComponent<NavMeshAgent>();
        //Set the postion of the enemy and the postion of the first waypoint 
        Navigation.SetDestination(waypoints[waypointIndex].transform.position);

        Player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    private void Update()
    {
        // Move the enemy 
        Move();
        CheckVision();
    }

    private void CheckVision()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, VisionRadius, transform.forward); 
        foreach(RaycastHit hit in hits)

        {
            if (hit.collider.gameObject.tag == "Player")
            {

                chasingcharacter = true;
                return;
            }


        }

        chasingcharacter = false;

    }

    //Make the enemy walk
    private void Move()
    {
        if (chasingcharacter)
        {

            Navigation.SetDestination(Player.transform.position);
            
        }
        else
        {
            // Move the enemy from the current waypoint to the next
            Navigation.SetDestination(waypoints[waypointIndex].transform.position);
        }
    }

    // Set amount of waypoints 
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out WayPointID waypointID))
        {
            if (waypointID.ID == waypointIndex)
            {
                waypointIndex = (int) Mathf.Repeat(++waypointIndex, waypoints.Length);

            }
        }
    }

}
