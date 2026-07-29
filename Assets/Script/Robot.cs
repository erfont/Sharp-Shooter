using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    [SerializeField] GameObject target;

    NavMeshAgent navMeshAgent;

    FirstPersonController player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

    }
    void Start()
    {
        //navMeshAgent.SetDestination(targetTransform.position);
        player = FindAnyObjectByType<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target) navMeshAgent.SetDestination(target.transform.position);
        else navMeshAgent.SetDestination(player.transform.position);
    }
}
