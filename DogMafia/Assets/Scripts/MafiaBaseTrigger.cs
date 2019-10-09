using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MafiaBaseTrigger : Interactable
{

    //this goes to the mafia base
    private GameObject playerObj;
    private Vector2 door;

    public override void Interact()
    {
        Debug.Log("Going to Mafia Base Trigger");
        //door = GameObject.FindGameObjectWithTag("Overworld Mafia Base Door").transform.position;
        Vector2 newPosition = new Vector2(36.8329f, -44.539f);
        if (playerObj == null)
            playerObj = GameObject.Find("Player");
        playerObj.transform.position = newPosition;
        //playerObj.transform.position = door;

    }
    
}