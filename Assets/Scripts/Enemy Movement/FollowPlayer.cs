using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class FollowPlayer : MonoBehaviour
{
    public Transform Follow;

    UnityEngine.AI.NavMeshAgent agent;
    float timer = 0;

    //Initalization 

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    //update is called once per frame

    void Update()
    {
        if (timer <= 0)
        {
            agent.SetDestination(Follow.position);
            timer = 1;
        }
        timer -= Time.deltaTime;
    }
}
