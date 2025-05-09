using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollectible : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
            StarCounter.Instance.CollectStar();
            Destroy(gameObject, audioSource.clip.length);
        }
    }
}
