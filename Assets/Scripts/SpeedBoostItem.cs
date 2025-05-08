using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostItem : MonoBehaviour
{
    public float speedBoostAmount = 1.1f;
    public float boostDuration = 3f;

    private FPSController fpsController;
    private AudioSource audioSource;

    private void Start()
    {
        fpsController = FindObjectOfType<FPSController>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (fpsController != null)
            {
                fpsController.ApplySpeedBoost(speedBoostAmount, boostDuration);
            }
            else
            {
                Debug.LogError("FPSController is missing! Cannot apply speed boost.");
            }

            if (audioSource != null)
            {
                audioSource.Play();
                Destroy(gameObject, audioSource.clip.length); 
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
