using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    [SerializeField] GameObject target;

    NavMeshAgent navMeshAgent;

    FirstPersonController player;

    const string PLAYER_STRING = "Player";

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

    }
    void Start()
    {
        player = FindAnyObjectByType<FirstPersonController>();
        if (player) navMeshAgent.SetDestination(player.transform.position);
    }

    void Update()
    {
        if (target) navMeshAgent.SetDestination(target.transform.position);
        else navMeshAgent.SetDestination(player.transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_STRING))
        {
            Enemyhealth enemyHealth = GetComponent<Enemyhealth>();
            enemyHealth.SelfDestruct();    
        }
    }
}
