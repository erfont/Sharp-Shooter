using UnityEngine;

public class Enemyhealth : MonoBehaviour
{

    [SerializeField] int MaxHealth = 3;
    [SerializeField] Launcher enemyDrop;
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
            if (enemyDrop) Instantiate(enemyDrop, this.transform.position, Quaternion.identity);
        }
    }
}
