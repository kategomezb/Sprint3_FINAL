using UnityEngine;

public class CowHealth : MonoBehaviour
{
    public float maxHealth = 100f;   
    private float currentHealth;     

    void Start()
    {
        currentHealth = maxHealth;  
    }


    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();  
        }
    }

   
    private void Die()
    {
        Debug.Log("The cow has died!");
    }

    
    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
