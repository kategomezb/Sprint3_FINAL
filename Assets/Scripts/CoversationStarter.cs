using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConversationStarter : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;
    private bool isTalking = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !isTalking)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                isTalking = true;

                // Unlock cursor for dialogue
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                ConversationManager.Instance.StartConversation(myConversation);
                ConversationManager.OnConversationEnded += EndConversation;
            }
        }
    }

    private void EndConversation()
    {
        isTalking = false;

        // Lock cursor back after dialogue
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        ConversationManager.OnConversationEnded -= EndConversation;
    }
}

