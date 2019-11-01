using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLocation : MonoBehaviour
{
    public QuestManager qManager;
    public QuestEvent qEvent;
    public QuestButton qButton;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Player") return;
        else{
            Debug.Log("hit the quest");
        }

        if(qEvent.eventStatus != QuestEvent.EventStatus.CURRENT) return;

        //as long as these three conditions are sent back then it can be sent anywhere
        qEvent.UpdateQuestEvent(QuestEvent.EventStatus.DONE);
        qButton.UpdateButton(QuestEvent.EventStatus.DONE);
        qManager.UpdateQuestsOnCompletion(qEvent);
    }

    public void Setup(QuestManager qm, QuestEvent qe, QuestButton qb)
    {
        qManager = qm;
        qEvent = qe;
        qButton = qb;

        qe.button = qButton;
    }

}
