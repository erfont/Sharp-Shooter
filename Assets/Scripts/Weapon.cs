using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;
        
    public void Shoot(WeaponSO weaponSO)
    {
        RaycastHit hit;
        muzzleFlash.Play();

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            Enemyhealth enemyhealth = hit.collider.GetComponent<Enemyhealth>();
            enemyhealth?.TakeDamage(weaponSO.Damage); // if (enemyhealth) enemyhealth.TakeDamage(weaponSO.Damage);
            if (!hit.collider.CompareTag("InvisibleWall")) Instantiate(weaponSO.HitVFXPrefab, hit.point, Quaternion.identity);
        }

        
    }
}
