using System.Collections;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] GameObject robotPrefab;
    [SerializeField] float spawnTime = 5f;
    [SerializeField] Transform spawnPoint;
    PlayerHealth player;

    private void Start()
    {
        
        player = FindAnyObjectByType<PlayerHealth>();
        StartCoroutine(SpawnRoutine());
    }
    IEnumerator SpawnRoutine()
    {
        while (player)
        {
            Debug.Log("hi");
            Instantiate(robotPrefab, spawnPoint.position, transform.rotation);
            yield return new WaitForSeconds(spawnTime);
        }

    }
}
