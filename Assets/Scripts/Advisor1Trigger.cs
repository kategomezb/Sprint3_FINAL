using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advisor1Trigger : MonoBehaviour
{
    [SerializeField] private Advisor1NPCSystem npcSystem; 
    [SerializeField] private AudioSource npcSound;


    private void OnTriggerEnter(Collider other)
    {
 
        if (other.CompareTag("Player"))
        {

            npcSystem.ShowDialogue(npcSystem.testDialogue);
            npcSound.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
   
        if (other.CompareTag("Player"))
        {

            npcSystem.CloseDialogueBox();
            npcSound.Stop();
        }
    }
}
