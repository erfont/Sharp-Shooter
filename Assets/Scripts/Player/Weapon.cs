using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

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

        int nonShootableLayerMask = 1 << LayerMask.NameToLayer("NonShootable");

        int UILayerMask = 1 << LayerMask.NameToLayer("UI");

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, weaponSO.shootDistance, ~nonShootableLayerMask)) // Invert the mask using '~' to hit everything except 'nonShootableLayerMask'
        {
            Enemyhealth enemyhealth = hit.collider.GetComponentInParent<Enemyhealth>();
            enemyhealth?.TakeDamage(weaponSO.Damage, weaponSO.name); // if (enemyhealth) enemyhealth.TakeDamage(weaponSO.Damage);
            //if (!hit.collider.CompareTag("NonShootable")) // not necessary anymore
            Instantiate(weaponSO.HitVFXPrefab, hit.point, Quaternion.identity);
        }

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, weaponSO.shootDistance, UILayerMask))
        {
            Test test = hit.collider.GetComponentInParent<Test>();
            test.ButtonShot();
        }


        
    }
}
