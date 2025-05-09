using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advisor2Trigger : MonoBehaviour
{
    [SerializeField] private Advisor2NPCSystem npcSystem;// This is my reference to the NPCSystem
    [SerializeField] private AudioSource npcSound;


    private void OnTriggerEnter(Collider other)
    {
        // This will help me to check if the player enters the trigger zone
        if (other.CompareTag("Player"))
        {

            npcSystem.ShowDialogue(npcSystem.testDialogue);
            npcSound.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // This will help me to check if the player exits the trigger zone
        if (other.CompareTag("Player"))
        {

            npcSystem.CloseDialogueBox();
            npcSound.Stop();
        }
    }
}