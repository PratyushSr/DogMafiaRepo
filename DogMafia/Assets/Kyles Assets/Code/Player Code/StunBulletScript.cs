using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunBulletScript : MonoBehaviour
{
    public float speed = 20f;
    public float stunDuration = 3;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public MouseLocator ml;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {

        RangedEnemy re = hitInfo.GetComponent<RangedEnemy>();
        MeleeEnemy me = hitInfo.GetComponent<MeleeEnemy>();
        if(re != null)
        {
            re.Stun(stunDuration);
        }else if (me != null)
        {
            me.Stun(stunDuration);
        }

        if (impactEffect != null)
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
