using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC_Slime : MonoBehaviour, IInteractable
{
    /// <summary>
    /// 출력할 문장들입니다.
    /// </summary>
    private List<string> dialogueLines = new List<string>
    {
        "Hello Chilguy",
        "This is a weird place",
        "Get away as fast as you can",
        "Then goodbye",
    };

    public void Interact()
    {
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        if (dialogueManager != null)
        {
            dialogueManager.StartDialogue(dialogueLines);
        }
    }
}
