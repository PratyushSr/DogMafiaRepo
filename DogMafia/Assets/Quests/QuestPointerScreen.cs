using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class QuestPointerScreen : MonoBehaviour
{
    // [SerializeField] private Camera uiCamera;
    private Vector3 targetPosition;
    private RectTransform pointerRectTransform;
    public GameObject target;
    private void Awake()
    {
        //targetPosition = new Vector3(200,45); //changing 200, 45 to the actual position of the quest
        targetPosition = target.transform.position;
        pointerRectTransform = transform.Find("Pointer").GetComponent<RectTransform>();
    }

    private void Update()
    {

        Vector3 toPosition = targetPosition;
        //Vector3 fromPosition = Camera.main.transform.position;
        Vector3 fromPosition = GameManager.instance.player.position;
        fromPosition.z = 0f;
        Vector3 direction = (toPosition - fromPosition).normalized;

        // float angleToTarget = Vector3.SignedAngle(direction, player.transform.up, player.transform.right);
        // float angleToTarget = Vector3.SignedAngle(direction, toPosition, player.transform.forward);
        // angleToTarget = Mathf.Clamp(angleToTarget, -90, 90) / 360.0f;

        // pointerRectTransform.localEulerAngles = new Vector3(0, 0, angleToTarget);
        float angle = UtilsClass.GetAngleFromVectorFloat(direction) - 90f;
        //Debug.Log("angle: " + angle);
        pointerRectTransform.localEulerAngles = new Vector3(0, 0, angle);

        float borderSize = 100f;
        Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(targetPosition);
        bool isOffScreen = 
            targetPositionScreenPoint.x <= borderSize || 
            targetPositionScreenPoint.x >= Screen.width - borderSize || 
            targetPositionScreenPoint.y <= 0 || 
            targetPositionScreenPoint.y >= Screen.height;
        //Debug.Log(isOffScreen + " " + targetPositionScreenPoint);

        // if(isOffScreen)
        // {
        //     Vector3 cappedTargetScreenPosition = targetPositionScreenPoint;
        //     if(cappedTargetScreenPosition.x <= borderSize) cappedTargetScreenPosition.x = borderSize;
        //     if(cappedTargetScreenPosition.x >= Screen.width - borderSize) cappedTargetScreenPosition.x = Screen.width - borderSize;
        //     if(cappedTargetScreenPosition.y <= borderSize) cappedTargetScreenPosition.y = borderSize;
        //     if(cappedTargetScreenPosition.y >= Screen.height - borderSize) cappedTargetScreenPosition.y = Screen.height - borderSize;

        //     Vector3 pointerWorldPosition = uiCamera.ScreenToWorldPoint(cappedTargetScreenPosition);

        //     pointerRectTransform.position = pointerWorldPosition;
        //     pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x, pointerRectTransform.localPosition.y, 0f);
        // }
        if(!isOffScreen)
        {
            
        }
    }
}
