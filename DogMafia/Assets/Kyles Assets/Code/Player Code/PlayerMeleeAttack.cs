using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public float speed = 20f;
    public float damage = 50;
    public Rigidbody2D rb;
    public GameObject impactEffect;
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
        DestructableObject obj = hitInfo.GetComponent<DestructableObject>();
        if (re != null) //damage ranged enemy
        {
            re.TakeDamage(damage);
        }else if (me != null) //damaged melee enemy
        {
            me.TakeDamage(damage);
        } else if (obj != null) //damaged object
        {
            obj.TakeDamage(damage);
        }
        Die();
    }
    void Die()
    {
        if (impactEffect != null)
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
