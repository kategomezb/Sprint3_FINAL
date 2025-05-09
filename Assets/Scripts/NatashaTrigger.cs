using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatashaTrigger : MonoBehaviour
{
    [SerializeField] private NPCSystem2 npcSystem; 



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
