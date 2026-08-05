using System;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float radius = 1.5f;
    [SerializeField] int damage = 3;

    void Start()
    {
        Explode();
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.purple;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    private void Explode()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider hitCollider in hitColliders)
        {
            PlayerHealth playerHealth = hitCollider.GetComponent<PlayerHealth>();

            if (!playerHealth) continue;

            playerHealth.TakeDamage(damage);
            break;
    
        }
    }
}
