using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LamarFollow : MonoBehaviour
{
    public Transform player;  // Reference to the player's position (Esther)
    private NavMeshAgent agent;  // Reference to the NavMeshAgent
    public float stopDistance = 2f;  // Minimum distance Lamar should maintain from the player
    public float followSpeed = 3.5f;  // Speed at which Lamar follows the player
    public float idleSpeed = 0f;  // Speed when Lamar is idle (stopped)

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();  // Get the NavMeshAgent component attached to Lamar
        agent.speed = followSpeed;  // Set the follow speed
    }

    void Update()
    {
        if (player != null)
        {
            // Calculate the distance between Lamar and the player
            float distance = Vector3.Distance(transform.position, player.position);

            // If Lamar is too close to the player, stop following
            if (distance < stopDistance)
            {
                // Stop Lamar from moving by setting speed to idle
                agent.speed = idleSpeed;
                // Ensure Lamar stops moving and stays in place
                agent.SetDestination(transform.position);
            }
            else
            {
                // Resume following the player at the follow speed
                agent.speed = followSpeed;
                agent.SetDestination(player.position);
            }
        }
    }
}
