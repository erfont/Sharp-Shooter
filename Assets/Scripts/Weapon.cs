using Unity.Cinemachine;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;

    CinemachineImpulseSource impulseSource;

    private void Awake() 
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();    
    }
        
    public void Shoot(WeaponSO weaponSO)
    {
        RaycastHit hit;
        muzzleFlash.Play();
        impulseSource.GenerateImpulse();

        int layerMask = 1 << LayerMask.NameToLayer("NonShootable");

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, weaponSO.shootDistance, ~layerMask)) // Invert the mask using '~' to hit everything except 'IgnoreCast'
        {
            Enemyhealth enemyhealth = hit.collider.GetComponent<Enemyhealth>();
            enemyhealth?.TakeDamage(weaponSO.Damage); // if (enemyhealth) enemyhealth.TakeDamage(weaponSO.Damage);
            if (!hit.collider.CompareTag("NonShootable")) Instantiate(weaponSO.HitVFXPrefab, hit.point, Quaternion.identity);
        }

        
    }
}
