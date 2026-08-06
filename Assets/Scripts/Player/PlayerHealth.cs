using UnityEngine.UI;
using Unity.Cinemachine;
using UnityEngine;
using System;
using StarterAssets;

public class PlayerHealth : MonoBehaviour
{
    [Range(1,10)]
    [SerializeField] public int StartHealth = 5;
    [Range(1,10)]
    [SerializeField] public int MaxHealth = 10;
    [SerializeField] CinemachineVirtualCamera deathVirtualCamera;
    [SerializeField] Transform weaponCamera;
    [SerializeField] Image[] shieldBars;
    [SerializeField] GameObject gameOverContainer;
    [SerializeField] Image crossHair;
    int currentHealth;
    int gameOverVirtualCameraPriority = 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = StartHealth;
        crossHair.enabled = true;
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
            PlayerGameOver();
        }
    }

    private void PlayerGameOver()
    {
        weaponCamera.parent = null; // un-parent the camera before destroy its parent on player death
        deathVirtualCamera.Priority = gameOverVirtualCameraPriority;
        gameOverContainer.SetActive(true);
        StarterAssetsInputs starterAssetsInputs = FindAnyObjectByType<StarterAssetsInputs>();
        starterAssetsInputs.SetCursorState(false);
        crossHair.enabled = false;
        Destroy(this.gameObject);
    }

    public void Heal(int amount)
    {
        Debug.Log("From "+ currentHealth + " adding "+ amount);
        if (currentHealth + amount > MaxHealth) currentHealth = MaxHealth;
        else currentHealth += amount;
        AdjustShieldUI();

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
