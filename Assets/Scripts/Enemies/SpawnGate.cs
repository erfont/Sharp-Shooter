using System.Collections;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] GameObject robotPrefab;
    [SerializeField] float spawnTime = 5f;
    [SerializeField] Transform spawnPoint;
    PlayerHealth player;

    GameManager gameManager;

    private void Start()
    {        
        player = FindAnyObjectByType<PlayerHealth>();
        gameManager = FindAnyObjectByType<GameManager>();
        StartCoroutine(SpawnRoutine());
    }
    IEnumerator SpawnRoutine()
    {
        while (player)
        {
            Instantiate(robotPrefab, spawnPoint.position, transform.rotation);
          //  gameManager.AdjustEnemiesLeft(1);
            yield return new WaitForSeconds(spawnTime);
        }

    }
}
