using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Slider healthSlider;    // UI slider reference
    public Image fill;             // The fill image inside the slider
    public Gradient gradient;      // Gradient from green to red

    void Start()
    {
        currentHealth = maxHealth;

        // Initialize slider and color
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        fill.color = gradient.Evaluate(1f); // Full health = green
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        UpdateHealthBar();
        Debug.Log("Player healed. Current health: " + currentHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHealthBar();
        Debug.Log("Player took damage. Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart the scene
    }

    void UpdateHealthBar()
    {
        healthSlider.value = currentHealth;

        // Update color based on current health %
        fill.color = gradient.Evaluate(healthSlider.normalizedValue);
    }
}
