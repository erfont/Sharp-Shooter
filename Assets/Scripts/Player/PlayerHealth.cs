using UnityEngine.UI;
using Unity.Cinemachine;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    [Range(1,10)]
    [SerializeField] int MaxHealth = 10;
    [SerializeField] CinemachineVirtualCamera deathVirtualCamera;
    [SerializeField] Transform weaponCamera;
    [SerializeField] Image[] shieldBars;
    int currentHealth;
    int gameOverVirtualCameraPriority = 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = MaxHealth;
        AdjustShieldUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        AdjustShieldUI();

        if (currentHealth <= 0)
        {
            weaponCamera.parent = null; // un-parent the camera before destroy its parent on player death
            deathVirtualCamera.Priority = gameOverVirtualCameraPriority;
            Destroy(this.gameObject);
        }
    }

    private void AdjustShieldUI()
    {
        for (int i = 0; i < shieldBars.Length; i++)
        {
            if (i < currentHealth)
            {
                shieldBars[i].gameObject.SetActive(true);
            }
            else shieldBars[i].gameObject.SetActive(false);
        }
    }
}
