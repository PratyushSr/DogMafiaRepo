using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassController : MonoBehaviour
{
    public GameObject pointer;
    public GameObject target;
    public GameObject player;
    public RectTransform compassLine;
    RectTransform rect;

    void Start()
    {
        rect = pointer.GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector3[] compassBarPosition = new Vector3[4];
        compassLine.GetLocalCorners(compassBarPosition);
        float pointerScale = Vector3.Distance(compassBarPosition[1], compassBarPosition[2]); //bottom corners
        //Debug.Log("1 " + compassBarPosition[1] + " 2 " + compassBarPosition[2]);
        //1: -351.5, 11.6, 0
        //2: 351.5, 11.6, 0

        Vector2 direction = target.transform.position - player.transform.position;
        // Debug.Log(direction[0]);
        float angleToTarget = Vector2.SignedAngle(direction, player.transform.up); //player.transform.up is for 3d
        //Debug.Log("angle " + angleToTarget);

        angleToTarget = Mathf.Clamp(angleToTarget, -90, 90) / 180.0f * pointerScale;
        rect.localPosition = new Vector2(angleToTarget, rect.localPosition.y); //z is for 3d

    }
}