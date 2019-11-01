using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public Quest quest = new Quest();
    public GameObject questPrintBox;
    public GameObject buttonPrefab;
    public GameObject A, B, C, D, E;
    // public GameObject[] questObjects; //added
    // public List<QuestBase.questInfo> questInfo; //added

    void Start()
    {
        //questInfo = new List<QuestBase.questInfo>(); //added
        QuestEvent a = quest.AddQuestEvent("Talk to Tiny", "Find Tiny and talk to him", A);
        QuestEvent b = quest.AddQuestEvent("test2", "description2", B);
        QuestEvent c = quest.AddQuestEvent("test3", "description3", C);
        QuestEvent d = quest.AddQuestEvent("test4", "description4", D);
        QuestEvent e = quest.AddQuestEvent("test5", "description5", E);

        // foreach(QuestBase.questInfo i in questInfo)
        // {
        //     quest.AddQuestEvent(i);
        // }
        
        quest.AddPath(a.GetID(), b.GetID());
        quest.AddPath(b.GetID(), c.GetID());
        quest.AddPath(b.GetID(), d.GetID());
        quest.AddPath(c.GetID(), e.GetID());
        quest.AddPath(d.GetID(), e.GetID());

        // foreach(QuestBase.questInfo i in questInfo)
        // {
        //     quest.AddPath(questInfo.from_quest_event, questInfo.to_quest_event);
        // }


        quest.BFS(a.GetID());

        QuestButton button = CreateButton(a).GetComponent<QuestButton>(); //sends first event a
        A.GetComponent<QuestLocation>().Setup(this, a, button);
        button = CreateButton(b).GetComponent<QuestButton>(); //sends first event b
        B.GetComponent<QuestLocation>().Setup(this, b, button);
        button = CreateButton(c).GetComponent<QuestButton>(); //sends first event c
        C.GetComponent<QuestLocation>().Setup(this, c, button);
        button = CreateButton(d).GetComponent<QuestButton>(); //sends first event d
        D.GetComponent<QuestLocation>().Setup(this, d, button);
        button = CreateButton(e).GetComponent<QuestButton>(); //sends first event e
        E.GetComponent<QuestLocation>().Setup(this, e, button);
        // foreach(int i in questObjects)
        // {
        //     questObjects[i].GetComponent<QuestLocation>().Setup(this, a, button);
        // }
        quest.PrintPath();
    }

    GameObject CreateButton(QuestEvent e)
    {
        GameObject b = Instantiate(buttonPrefab);
        b.GetComponent<QuestButton>().Setup(e, questPrintBox);
        if(e.eventOrder == 1)
        {
            b.GetComponent<QuestButton>().UpdateButton(QuestEvent.EventStatus.CURRENT);
            e.eventStatus = QuestEvent.EventStatus.CURRENT;
        }
        return b;
    }

    public void UpdateQuestsOnCompletion(QuestEvent e)
    {
        foreach(QuestEvent i in quest.questEvents)
        {
            if(i.eventOrder == e.eventOrder + 1)
            {
                i.UpdateQuestEvent(QuestEvent.EventStatus.CURRENT);
            }
        }
    }
}
