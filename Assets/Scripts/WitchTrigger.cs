using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchTrigger : MonoBehaviour
{
    [SerializeField] private WitchNPCSystem npcSystem;  

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {

            npcSystem.ShowDialogue(npcSystem.testDialogue);  
        }
    }

    private void OnTriggerExit(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {

            npcSystem.CloseDialogueBox();  
        }
    }
}