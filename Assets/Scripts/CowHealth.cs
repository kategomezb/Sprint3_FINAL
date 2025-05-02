using UnityEngine;

public class CowHealth : MonoBehaviour
{
    public float maxHealth = 100f;   // Maximum health for the cow
    private float currentHealth;     // Current health of the cow

    void Start()
    {
        currentHealth = maxHealth;  // Initialize the health at the start
    }

    // Method to reduce health when the cow touches the water
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();  // Call the Die method when health reaches 0
        }
    }

    // Method to handle the cow's death
    private void Die()
    {
        Debug.Log("The cow has died!");
        // You can play an animation or disable the cow here
    }

    // Method to retrieve current health
    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
