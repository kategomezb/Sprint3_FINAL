using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostItem : MonoBehaviour
{
    public float speedBoostAmount = 1.1f; // Amount of speed boost (e.g., 2x speed)
    public float boostDuration = 3f; // Duration of the speed boost

    private FPSController fpsController; // Reference to FPSController to modify player's speed

    private void Start()
    {
        // Find the FPSController component on the player (ensure this exists)
        fpsController = FindObjectOfType<FPSController>();
    }

    // When the player collides with the item
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the colliding object is the player
        {
            if (fpsController != null)
            {
                // Call the method to apply the speed boost
                fpsController.ApplySpeedBoost(speedBoostAmount, boostDuration);
            }
            else
            {
                Debug.LogError("FPSController is missing! Cannot apply speed boost.");
            }

            // Destroy the item after it is collected
            Destroy(gameObject);
        }
    }
}