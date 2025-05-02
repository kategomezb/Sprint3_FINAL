using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushiTrigger : MonoBehaviour
{
    [SerializeField] private MushiNPCSystem npcSystem;  // Reference to the NPCSystem



    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger zone
        if (other.CompareTag("Player"))
        {

            npcSystem.ShowDialogue(npcSystem.testDialogue);  // Show the dialogue when the player is in range
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player exits the trigger zone
        if (other.CompareTag("Player"))
        {

            npcSystem.CloseDialogueBox();  // Close the dialogue box when the player exits
        }
    }
}