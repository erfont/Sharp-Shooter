using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    StarterAssetsInputs starterAssetsInput;

    [SerializeField] int damageAmount = 1;
    [SerializeField] ParticleSystem muzzleFlash;

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

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            Enemyhealth enemyhealth = hit.collider.GetComponent<Enemyhealth>();
            enemyhealth?.TakeDamage(damageAmount); // if (enemyhealth) enemyhealth.TakeDamage(damageAmount);
        }

        starterAssetsInput.ShootInput(false);
        return true;
    }
}
