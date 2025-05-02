using DialogueEditor;
using UnityEngine;

public class ConversationScript : MonoBehaviour
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

                // Unlock and show the cursor
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                // Start the conversation
                ConversationManager.Instance.StartConversation(myConversation);

                // Listen for when the conversation ends
                ConversationManager.OnConversationEnded += EndConversation;
            }
        }
    }

    private void EndConversation()
    {
        isTalking = false;

        // Lock and hide the cursor again
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Stop listening for conversation end (to avoid multiple calls)
        ConversationManager.OnConversationEnded -= EndConversation;
    }
}