using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject gb;
    public string trigger;
    public bool value;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(trigger))
            gb.SetActive(value);
    }
}
