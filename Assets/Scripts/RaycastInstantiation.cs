using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInstantiation : MonoBehaviour
{
    public Camera playerCamera; 
    public GameObject objectToSpawn; 
    public float raycastDistance = 10f; 

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition); 
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, raycastDistance)) 
            {
                Instantiate(objectToSpawn, hit.point, Quaternion.identity); 
            }
        }
    }
}