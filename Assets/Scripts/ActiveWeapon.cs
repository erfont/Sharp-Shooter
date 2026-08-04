using StarterAssets;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    StarterAssetsInputs starterAssetsInput;
    Weapon currentWeapon;

    [SerializeField] WeaponSO startWeaponSO;
    [SerializeField] CinemachineVirtualCamera playerFollowCamera;
    [SerializeField] Camera weaponCamera;
    [SerializeField] GameObject zoomVignette;
    [SerializeField] TMP_Text ammoText;

    Animator animator;

    const string SHOOT_STRING = "Shoot";
    float timeSinceLastShot = 0f;
    float defaultFOV, defaultZoomRotationSpeed;
    int currentAmmo;
    FirstPersonController firstPersonController;
    WeaponSO currentWeaponSO;

    void Awake()
    {
        starterAssetsInput = GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
        defaultFOV = playerFollowCamera.m_Lens.FieldOfView;
        firstPersonController = GetComponentInParent<FirstPersonController>();
        defaultZoomRotationSpeed = firstPersonController.RotationSpeed;
    }

    void Start()
    {
        SwitchWeapon(startWeaponSO, true);
        currentWeapon = GetComponentInChildren<Weapon>();
        AdjustAmmo(currentWeaponSO.magazineSize, true);
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
       
        HandleShoot();
        HandleZoom();
          
    }

    public void AdjustAmmo(int amount, bool isReset)
    {
        if (isReset) currentAmmo = amount;
        else currentAmmo += amount;
        SetAmmoText(currentAmmo);   
    }

    public void AdjustAmmoPercentage(int percent)
    {
        int amount = Mathf.RoundToInt(currentWeaponSO.magazineSize * percent / 100);
        currentAmmo += amount;     
        SetAmmoText(currentAmmo);   
    }

    private void SetAmmoText(int ammo)
    {
        ammoText.text = ammo.ToString("D2");
    }

    private void HandleShoot()
    {
        if (!starterAssetsInput.shoot) return;
        if (timeSinceLastShot <= currentWeaponSO.FireRate) return;
        if (currentAmmo <= 0) return;

        timeSinceLastShot = 0;    
        AdjustAmmo(-1, false);       
        currentWeapon.Shoot(currentWeaponSO);
        animator.Play(SHOOT_STRING, 0, 0f);

        if (!currentWeaponSO.IsAutomatic)
        {
            starterAssetsInput.ShootInput(false);
        }
        
  
    }

    private void HandleZoom()
    {
        if (!currentWeaponSO.CanZoom) return;
        if (starterAssetsInput.zoom)
        {
            zoomVignette.SetActive(true);
            playerFollowCamera.m_Lens.FieldOfView = currentWeaponSO.ZoomAmount;
            weaponCamera.fieldOfView = currentWeaponSO.ZoomAmount; // gets the sniper rifle tip off the vignette
            firstPersonController.ChangeRotationSpeed(currentWeaponSO.ZoomRotationSpeed);
        }
        else 
        {
            zoomVignette.SetActive(false);
            playerFollowCamera.m_Lens.FieldOfView = defaultFOV;
            weaponCamera.fieldOfView = defaultFOV;
            firstPersonController.ChangeRotationSpeed(defaultZoomRotationSpeed);

        }
        
    }

    public void SwitchWeapon(WeaponSO weaponSO, bool isStart)
    {
        if (isStart)
        {
            Weapon newWeapon = Instantiate(weaponSO.weaponPrefab, transform).GetComponent<Weapon>();
            currentWeapon = newWeapon;
            this.currentWeaponSO = weaponSO;
            this.AdjustAmmo(weaponSO.magazineSize, false);
            animator.runtimeAnimatorController = weaponSO.weaponAnimator;
            Debug.Log("Player starts with " + weaponSO.name); 
            return;
        }

        if (!weaponSO.name.Equals(currentWeaponSO.name))
        {
            Destroy(currentWeapon.gameObject);
            Weapon newWeapon = Instantiate(weaponSO.weaponPrefab, transform).GetComponent<Weapon>();
            currentWeapon = newWeapon;
            this.currentWeaponSO = weaponSO;
            this.AdjustAmmo(weaponSO.magazineSize, true);
            animator.runtimeAnimatorController = weaponSO.weaponAnimator;
            Debug.Log("Player picked up " + weaponSO.name); 
        }
        else
        {
            this.AdjustAmmo(weaponSO.magazineSize, false);
            Debug.Log("Player got " + currentWeaponSO.magazineSize + " " + currentWeaponSO.name + "rounds");
        }
  
        
        
    }
}
