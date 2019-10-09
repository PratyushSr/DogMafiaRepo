using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    //defined variables
    public float speed; //how fast the enemy is gonna move
    private Transform target;

    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > 1) //only makes the enenmy move towards the player when a certain distance away
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); //moves the enemy towards the player
        }
        
    }


}
