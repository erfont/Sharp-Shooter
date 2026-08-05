using System;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float radius = 1.5f;

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
        throw new NotImplementedException();
    }
}
