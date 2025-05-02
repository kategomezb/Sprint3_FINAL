using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDrop : MonoBehaviour
{
    public GameObject healthItemPrefab; // assign in Inspector
    public float interactionRange = 3f; // how close player needs to be

    private Transform player;
    private bool hasDropped = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= interactionRange && Input.GetKeyDown(KeyCode.H) && !hasDropped)
        {
            Vector3 dropPosition = transform.position + transform.forward; // in front of NPC
            Instantiate(healthItemPrefab, dropPosition, Quaternion.identity);
            hasDropped = true;
        }
    }
}