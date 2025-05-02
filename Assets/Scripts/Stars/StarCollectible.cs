using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StarCounter.Instance.CollectStar();
            Destroy(gameObject); // remove the star
        }
    }
}
