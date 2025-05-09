using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassRoomDestruction : MonoBehaviour
{
    public GameObject glassRoom; 

    public void DestroyGlassRoom()
    {
        if (glassRoom != null)
        {
            Destroy(glassRoom); 
            Debug.Log("Glass room destroyed");
        }
        else
        {
            Debug.LogWarning("Glass room is not assigned or is null.");
        }
    }
}