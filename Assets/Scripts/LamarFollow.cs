using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LamarFollow : MonoBehaviour
{
    public Transform player;  
    private NavMeshAgent agent; 
    public float stopDistance = 2f;  
    public float followSpeed = 3.5f;  
    public float idleSpeed = 0f;  

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); 
        agent.speed = followSpeed;  
    }

    void Update()
    {
        if (player != null)
        {
            
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance < stopDistance)
            {
                // This will help me to stop Lamar from moving by setting speed to idle
                agent.speed = idleSpeed;
                agent.SetDestination(transform.position);
            }
            else
            {
                agent.speed = followSpeed;
                agent.SetDestination(player.position);
            }
        }
    }
}
