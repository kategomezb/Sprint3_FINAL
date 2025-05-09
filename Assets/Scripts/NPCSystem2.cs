using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCSystem2 : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;               
    [SerializeField] public DialogueObject testDialogue;  
    [SerializeField] private GameObject dialogueBox;   

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
    public void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}