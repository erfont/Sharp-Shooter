using StarterAssets;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    StarterAssetsInputs starterAssetsInput;
    Weapon currentWeapon;

    [SerializeField] WeaponSO weaponSO;
    Animator animator;

    const string SHOOT_STRING = "Shoot";

    void Awake()
    {
        starterAssetsInput = GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        currentWeapon = GetComponentInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleShoot();
    }

    private void HandleShoot()
    {
        if (!starterAssetsInput.shoot) return;
        currentWeapon.Shoot(weaponSO);
        animator.Play(SHOOT_STRING, 0, 0f);
        starterAssetsInput.ShootInput(false);

  
    }
}
