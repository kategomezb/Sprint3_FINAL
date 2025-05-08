using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollectible : MonoBehaviour
{
    private AudioSource starAudio;
    private bool collected = false;

    private void Start()
    {
        starAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!collected && other.CompareTag("Player"))
        {
            collected = true;

            // Play the sound
            if (starAudio != null)
            {
                starAudio.Play();
            }

            // Update star count
            StarCounter.Instance.CollectStar();

            // Destroy after the sound finishes
            Destroy(gameObject, starAudio.clip.length);
        }
    }
}
