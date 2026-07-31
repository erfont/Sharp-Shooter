using StarterAssets;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    StarterAssetsInputs starterAssetsInput;
    Weapon currentWeapon;

    [SerializeField] WeaponSO weaponSO;
    Animator animator;

    const string SHOOT_STRING = "Shoot";

    float timeSinceLastShot = 0f;

    void Awake()
    {
        starterAssetsInput = GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
                SwitchWeapon(weaponSO);

        currentWeapon = GetComponentInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
       
        HandleShoot();
          
    }

    private void HandleShoot()
    {
        if (!starterAssetsInput.shoot) return;
        if (timeSinceLastShot <= weaponSO.FireRate) return;

        timeSinceLastShot = 0;           
        currentWeapon.Shoot(weaponSO);
        animator.Play(SHOOT_STRING, 0, 0f);

        if (!weaponSO.IsAutomatic)
        {
            starterAssetsInput.ShootInput(false);
        }
        

  
    }

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        if (currentWeapon)
        {
            Destroy(currentWeapon.gameObject);
        }

        Weapon newWeapon = Instantiate(weaponSO.weaponPrefab, transform).GetComponent<Weapon>();
        currentWeapon = newWeapon;
        this.weaponSO = weaponSO;

        Debug.Log("Player picked up " + weaponSO.name);
    }
}
