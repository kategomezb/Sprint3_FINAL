using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MushiNPCSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;                 // The text field where dialogue is shown
    [SerializeField] public DialogueObject testDialogue;      // The dialogue to display
    [SerializeField] private GameObject dialogueBox;             // The dialogue UI box

    private TypewriterEffect typewriterEffect;

    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        CloseDialogueBox();
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        foreach (string dialogue in dialogueObject.Dialogue)
        {
            yield return typewriterEffect.Run(dialogue, textLabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.T));
        }

        CloseDialogueBox();
    }

    // Change this method to public to allow other scripts to call it
    public void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}