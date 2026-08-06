using System.Collections;
using NUnit.Framework.Constraints;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform turretHead;
    [SerializeField] Transform playerTargetPoint; // We grab the camera root so that turrets don't aim at player's feet
    [SerializeField] Transform projectileSpawnPoint;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float fireRate = 4f;
    [SerializeField] int damage = 2;

    PlayerHealth player;

    void Start()
    {
        player = FindAnyObjectByType<PlayerHealth>();
        StartCoroutine(FireRoutine());
    }
    void Update()
    {
        if (player) turretHead.LookAt(playerTargetPoint.position);
    }

    IEnumerator FireRoutine()
    {
        while(player)
        {
            yield return new WaitForSeconds(fireRate);
            Projectile newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, turretHead.rotation).GetComponent<Projectile>();
            newProjectile.transform.LookAt(playerTargetPoint);            
            newProjectile.Init(damage);
        }
    }
}
