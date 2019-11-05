using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quests 
{
    public List<QuestEvent> questEvents = new List<QuestEvent>();
    // List<QuestEvent> pathList = new List<QuestEvent>();

    public Quests(){ }

    public QuestEvent AddQuestEvent(string name, string description, GameObject l)
    {
        QuestEvent questEvent = new QuestEvent(name, description, l);
        questEvents.Add(questEvent);
        return questEvent;
    }
    //added below
    // public void AddQuestEvent(QuestBase qb)
    // {
    //     //QuestEvent questEvent = new QuestEvent<QuestBase.questInfo>();
    //     foreach(QuestBase.questInfo i in qb.missionInfo)
    //     {
    //         questEvents.Add(qb);
    //     }
    // }

    //constructs the path from the events
    //the string parameters are the IDs
    public void AddPath(string fromQuestEvent, string toQuestEvent)
    {
        QuestEvent from = FindQuestEvent(fromQuestEvent);
        QuestEvent to = FindQuestEvent(toQuestEvent);

        if(from != null && to != null)
        {
            QuestPath path = new QuestPath(from, to);
            from.pathList.Add(path);
        }
    }

    QuestEvent FindQuestEvent(string id)
    {
        foreach(QuestEvent i in questEvents)
        {
            if(i.GetID() == id)
                return i;
        }
        return null;
    }

    public void BFS(string id, int orderNumber = 1)
    {
        QuestEvent thisEvent = FindQuestEvent(id);
        thisEvent.eventOrder = orderNumber;

        foreach (QuestPath i in thisEvent.pathList)
        {
            if(i.endEvent.eventOrder == -1)
            {
                BFS(i.endEvent.GetID(), orderNumber + 1);
            }
        }
    }

    public void PrintPath()
    {
        foreach(QuestEvent i in questEvents)
        {
            Debug.Log(i.eventName + " " + i.eventOrder);
        }
    
    }
}
