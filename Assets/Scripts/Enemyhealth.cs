using UnityEngine;

public class Enemyhealth : MonoBehaviour
{

    [SerializeField] int MaxHealth = 3;
    [SerializeField] Launcher[] enemyDrops;    
    [SerializeField] GameObject robotExplosionVFX;
    int currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0) 
        {
            Destroy(this.gameObject);
            Instantiate(robotExplosionVFX, transform.position, Quaternion.identity);
            if (enemyDrops.Length>0)
            {
                int index = Random.Range(0, enemyDrops.Length);
                Instantiate(enemyDrops[index], this.transform.position, Quaternion.identity);
            }
        }
    }
}
