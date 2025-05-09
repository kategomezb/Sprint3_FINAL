using UnityEngine;
using UnityEngine.AI;

public class MonsterChase : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public float chaseRange = 10f;
    public int damageAmount = 20;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < chaseRange)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            agent.ResetPath();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                Debug.Log("Player entered trigger. Dealing damage.");
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
