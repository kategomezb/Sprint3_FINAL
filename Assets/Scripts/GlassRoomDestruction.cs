using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassRoomDestruction : MonoBehaviour
{
    public GameObject glassRoom;  // The glass room object to destroy

    // Call this method to destroy the glass room
    public void DestroyGlassRoom()
    {
        if (glassRoom != null)
        {
            Destroy(glassRoom); // Destroy the glass room
            Debug.Log("Glass room destroyed");
        }
        else
        {
            Debug.LogWarning("Glass room is not assigned or is null.");
        }
    }
}