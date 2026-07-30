using StarterAssets;
using Unity.Mathematics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    StarterAssetsInputs starterAssetsInput;

    [SerializeField] int damageAmount = 1;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject HitVFXPrefab;
    [SerializeField] Animator animator;

    const string SHOOT_STRING = "Shoot";

    void Awake()
    {
        starterAssetsInput = GetComponentInParent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleShoot();
    }

    private bool HandleShoot()
    {
        if (!starterAssetsInput.shoot) return false;

        muzzleFlash.Play();
        animator.Play(SHOOT_STRING, 0, 0f);
        starterAssetsInput.ShootInput(false);

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            Enemyhealth enemyhealth = hit.collider.GetComponent<Enemyhealth>();
            enemyhealth?.TakeDamage(damageAmount); // if (enemyhealth) enemyhealth.TakeDamage(damageAmount);
            Instantiate(HitVFXPrefab, hit.point, quaternion.identity);
        }

        
        return true;
    }
}
