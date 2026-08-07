using UnityEngine;

public class MojoPickup : Pickup
{
    [SerializeField] int mojoMultiplier = 1;

    protected override void OnPickup()
    {
         player.AdjustMojo(1*mojoMultiplier);
    }
}
