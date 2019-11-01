using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestEvent
{
    public enum EventStatus{ WAITING, CURRENT, DONE };

    public string eventName;
    public string eventDescription;
    public string eventID;
    public int eventOrder = -1;
    public EventStatus eventStatus;
    public QuestButton button;

    public List<QuestPath> pathList = new List<QuestPath>();

    public GameObject location;
    public QuestEvent(string name, string description, GameObject loc){

        eventID = Guid.NewGuid().ToString(); //creates a unique identifier id
        eventName = name;
        eventDescription = description;
        eventStatus = EventStatus.WAITING;
        location = loc;
    }

    public void UpdateQuestEvent(EventStatus newEventStatus )
    {
        eventStatus = newEventStatus;
        button.UpdateButton(newEventStatus);
    }

    public string GetID()
    {
        return eventID;
    }
    
}
