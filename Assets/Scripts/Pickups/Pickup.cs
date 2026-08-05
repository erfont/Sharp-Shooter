using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    const string PLAYER_STRING = "Player";
    protected PlayerHealth player;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_STRING))
        {
            player = FindAnyObjectByType<PlayerHealth>();
            ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
            OnPickup(activeWeapon);
            Destroy(this.gameObject);
        }
        
    }

    protected abstract void OnPickup(ActiveWeapon activeWeapon);
}
