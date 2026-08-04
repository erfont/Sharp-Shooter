using StarterAssets;
using Unity.Cinemachine;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    StarterAssetsInputs starterAssetsInput;
    Weapon currentWeapon;

    [SerializeField] WeaponSO weaponSO;
    [SerializeField] CinemachineVirtualCamera playerFollowCamera;
    [SerializeField] GameObject zoomVignette;

    Animator animator;

    const string SHOOT_STRING = "Shoot";
    float timeSinceLastShot = 0f;
    float defaultFOV, defaultZoomRotationSpeed;
    FirstPersonController firstPersonController;

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
        SwitchWeapon(weaponSO);

        currentWeapon = GetComponentInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
       
        HandleShoot();
        HandleZoom();
          
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

    private void HandleZoom()
    {
        if (!weaponSO.CanZoom) return;
        if (starterAssetsInput.zoom)
        {
            zoomVignette.SetActive(true);
            playerFollowCamera.m_Lens.FieldOfView = weaponSO.ZoomAmount;
            firstPersonController.ChangeRotationSpeed(weaponSO.ZoomRotationSpeed);
        }
        else 
        {
            zoomVignette.SetActive(false);
            playerFollowCamera.m_Lens.FieldOfView = defaultFOV;
            firstPersonController.ChangeRotationSpeed(defaultZoomRotationSpeed);

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

        animator.runtimeAnimatorController = weaponSO.weaponAnimator;
        
        Debug.Log("Player picked up " + weaponSO.name);
    }
}
