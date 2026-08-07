using UnityEngine;

public class Enemyhealth : MonoBehaviour
{

    [SerializeField] int MaxHealth = 3;
    [SerializeField] Launcher[] enemyDrops;    
    [SerializeField] GameObject robotExplosionVFX;

    GameManager gameManager;
    int currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        gameManager.AdjustEnemiesLeft(1);
        currentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount, string weaponName)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0) 
        {
            SelfDestruct(GetDropTypeFromWeapon(weaponName));            
        }
    }

    public void SelfDestruct(int dropType)
    {
        if (dropType > (enemyDrops.Length - 1)) dropType = 0;

        int dropIndex = 0;

        switch (dropType)
        {
            case 0:                
                break;
            case 1:
                dropIndex = Random.Range(1, enemyDrops.Length);                
                break;
            default:
                dropIndex = Random.Range(dropType, enemyDrops.Length);
                break;
        }

        Instantiate(enemyDrops[dropIndex], this.transform.position, Quaternion.identity);
        gameManager.AdjustEnemiesLeft(-1);
        Destroy(this.gameObject);
        Instantiate(robotExplosionVFX, transform.position, Quaternion.identity);

    }

    private int GetDropTypeFromWeapon(string weaponName)
    {
        int dropType = 0;

        if (weaponName.Equals("Pistol")) dropType = 1;
        else if (weaponName.Equals("Machinegun")) dropType = 2;
        else if (weaponName.Equals("Sniperrifle")) dropType = 3;
        Debug.Log(weaponName + " "+ dropType);
        
        return dropType;
    }
}
