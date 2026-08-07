using UnityEngine;

public class WeaponPickup : Pickup
{
    [SerializeField] WeaponSO weaponSO;

    protected override void OnPickup()
    {
        ActiveWeapon activeWeapon = player.GetComponentInChildren<ActiveWeapon>();

        activeWeapon.SwitchWeapon(weaponSO, false);
    }

}
