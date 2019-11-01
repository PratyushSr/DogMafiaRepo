using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestButton : MonoBehaviour
{
    public Button buttonComponent;
    public RawImage icon;
    public TextMeshProUGUI eventNameText;
    public Sprite currentIcon;
    public Sprite waitingIcon;
    public Sprite completedIcon;
    public QuestEvent thisEvent;
    QuestEvent.EventStatus status;
    public QuestPointerScreen arrow;

    void Awake()
    {
        buttonComponent.onClick.AddListener(ClickHandler);
        arrow = GameObject.Find("Pointer").GetComponent<QuestPointerScreen>();

    }

    public void Setup(QuestEvent e, GameObject scrollList)
    {
        thisEvent = e;
        buttonComponent.transform.SetParent(scrollList.transform, false);
        eventNameText.text = "<b>" + thisEvent.eventName + "</b>\n" + thisEvent.eventDescription;
        status = thisEvent.eventStatus;
        icon.texture = waitingIcon.texture;
        buttonComponent.interactable = false;
    }

    public void UpdateButton(QuestEvent.EventStatus s)
    {
        status = s;

        if(status == QuestEvent.EventStatus.DONE)
        {
            icon.texture = completedIcon.texture;
            buttonComponent.interactable = false;
        }
        else if(status == QuestEvent.EventStatus.WAITING)
        {
            icon.texture = waitingIcon.texture;
            buttonComponent.interactable = false;
        }
        else if(status == QuestEvent.EventStatus.CURRENT)
        {
            icon.texture = currentIcon.texture;
            buttonComponent.interactable = true;
        }
    }

    public void ClickHandler()
    {
        arrow.target = thisEvent.location;
    }
}
