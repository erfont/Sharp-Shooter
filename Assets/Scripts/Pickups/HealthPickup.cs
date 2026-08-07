using UnityEngine;

public class HealthPickup : Pickup
{
    [SerializeField] int healtPercent = 50;
    protected override void OnPickup()
    {
        
        int amount = Mathf.RoundToInt(player.MaxHealth * healtPercent / 100);
        Debug.Log(amount);
        player.Heal(amount);
    }

}

