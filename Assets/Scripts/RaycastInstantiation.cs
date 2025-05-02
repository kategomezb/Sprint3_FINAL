using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInstantiation : MonoBehaviour
{
    public Camera playerCamera; // Reference to the player's camera
    public GameObject objectToSpawn; // Prefab to spawn (e.g., glowing flower)
    public float raycastDistance = 10f; // Distance for the raycast to check

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Left-click to spawn object
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition); // Create ray from mouse position
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, raycastDistance)) // If ray hits something
            {
                Instantiate(objectToSpawn, hit.point, Quaternion.identity); // Spawn object at hit point
            }
        }
    }
}