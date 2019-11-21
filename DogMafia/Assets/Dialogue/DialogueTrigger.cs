using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueTrigger : Interactable
{
    public DialogueBase[] DB;
    [HideInInspector] public int index;
    public bool nextDialogueOnInteract;

    public void Start()
    {
        if (nextDialogueOnInteract)
        {
            index = -1;
        }
        else
        {
            index = 0;
        }

        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "Intro")
        {
            DialogueManager.instance.enqueueDialogue(DB[0]);
        }
    }
    public override void Interact()
    {
        Debug.Log("Interacted!");
        if (nextDialogueOnInteract && !DialogueManager.instance.inDialogue)
        {
            if (index < DB.Length - 1)
            {
                index++;
            }
        }
        DialogueManager.instance.enqueueDialogue(DB[index]);

    }
}
