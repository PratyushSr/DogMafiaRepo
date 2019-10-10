using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLocator : MonoBehaviour
{
    public GameObject player;
    public GameObject firePoint;
    public GameObject particle;
    
    void Start()
    {
        if(!Input.mousePresent) //if mouse not detected
        {
            Debug.Log("No mouse detected");
        }
        if(Camera.main == null) //if no main camera exists
        {
            Debug.Log("Warning: no camera attached");
            Debug.Log("Possible Fix: Check if the main camera has the tag <MainCamera>");
        }

    }

    void Update()
    {
        Debug.DrawRay(player.transform.position, MeleeVector(), Color.blue);
        Debug.DrawRay(firePoint.transform.position, VectorOfCursorRelativeToFirePoint(), Color.red);
    }
    public Vector2 MeleeVector() //assuming the map is flat
    {
        return new Vector2(Input.mousePosition.x - (Screen.width / 2) + Camera.main.transform.position.x - player.transform.position.x, Input.mousePosition.y - (Screen.height / 2) + Camera.main.transform.position.y - player.transform.position.y);
    }

    public Vector2 VectorOfCursorRelativeToFirePoint()
    {
        return new Vector2(Input.mousePosition.x - (Screen.width / 2) + Camera.main.transform.position.x - firePoint.transform.position.x, Input.mousePosition.y - (Screen.height / 2) + Camera.main.transform.position.y - firePoint.transform.position.y);
    }


}
