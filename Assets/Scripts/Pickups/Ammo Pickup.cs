using UnityEngine;

public class AmmoPickup : Pickup
{
    [SerializeField] int ammoPercent = 50;
    
    protected override void OnPickup()
    {
        ActiveWeapon activeWeapon = player.GetComponentInChildren<ActiveWeapon>();

        activeWeapon.AdjustAmmoPercentage(ammoPercent);
    }
}
