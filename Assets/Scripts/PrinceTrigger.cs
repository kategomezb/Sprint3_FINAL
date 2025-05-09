using UnityEngine;

public class PrinceTrigger : MonoBehaviour
{
    [SerializeField] private NPCSystem npcSystem;  

  

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
