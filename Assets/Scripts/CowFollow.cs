using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CowFollow : MonoBehaviour
{
    public Transform player;        // Reference to the player
    private NavMeshAgent agent;     // Reference to the NavMeshAgent

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }
}