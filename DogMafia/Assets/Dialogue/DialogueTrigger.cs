using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueTrigger : Interactable
{
    public DialogueBase[] DB;
    [HideInInspector] public int index;
    public bool nextDialogueOnInteract;
    private string sceneName;

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
        //this checks the scene for the intro

        Scene currentScene = SceneManager.GetActiveScene();

        sceneName = currentScene.name;
        
        if (sceneName == "Intro")
        {
            DialogueManager.instance.enqueueDialogue(DB[0]);
            
        }
        //this checks the scene for the mafia_base2
        else if (sceneName == "Mafia_Base2")
        {
            Debug.Log("entered mafia base dialogue");
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

    public void FixedUpdate()
    {
        if (sceneName == "Intro")
        {
            if (DialogueManager.instance.getEndOfDialogue())
            {
//                FadeInOut.instance.startFade("Mafia_Base2");

                SceneManager.LoadScene("Mafia_Base2");
            }
        }
        else if (sceneName == "Mafia_Base2")
        {
            if (DialogueManager.instance.getEndOfDialogue())
            {
//                FadeInOut.instance.startFade("MainOverworld");

                SceneManager.LoadScene("DM_Overworld_RankC");
            }
        }
    }
}
