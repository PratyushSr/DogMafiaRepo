using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestLogButton : MonoBehaviour
{
    [SerializeField] private GameObject questLog;

    void Start()
    {
        //questLog = GetComponent<Image>();
//        questLog = GetComponentInChildren<Image>();
        questLog = GetComponent<GameObject>();
        hideQuestLog();
    }

    public void hideQuestLog()
    {
        //questLog.enabled = false;
        questLog.SetActive(false);
    }

    public void showQuestLog()
    {
        questLog.SetActive(true);
        //questLog.enabled = true;
    }
    
}
