using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn1 : MonoBehaviour
{
    public GameObject location;
    public GameObject ObjToBeSpawned;
    public string button;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown(button) && ObjToBeSpawned != null && location != null)
        {
            Instantiate(ObjToBeSpawned, location.transform.position, Quaternion.identity);
        }
    }
}
