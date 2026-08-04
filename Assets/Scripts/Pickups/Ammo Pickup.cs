using UnityEngine;

public class AmmoPickup : Pickup
{
    [SerializeField] int ammoPercent = 50;
    protected override void OnPickup(ActiveWeapon activeWeapon)
    {
        activeWeapon.AdjustAmmoPercentage(ammoPercent);
    }
}
