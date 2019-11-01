using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Add Quest")]
public class QuestBase : ScriptableObject
{
    [System.Serializable]
    public class questInfo
    {
        public string quest_name;
        public string quest_description;
        public string from_quest_event;
        public string to_quest_event;
    }

    [Header("Insert Quests Below")]
    public questInfo[] missionInfo;

}
