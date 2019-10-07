using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float currentHealth = 100; //current health
    public float maxHealth = 100; //the max ammount of current health

    public float moveSpeed = 3f; //move speed

    public Rigidbody2D rb; //player rigid body component
    public Animator animator; //attach animator here

    public GameObject deathEffect; //effect on death
    private float stunDuration; //length of stun

    Vector2 movement;

    void Start()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

   void FixedUpdate()
   {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime); 
   }

    public void Heal(float health) //heals enemy for set ammount
    {
        if (health > 0) //make sure health is positive float
        {
            //--------------------ADD SCRIPT TO TRIGGER ANIMATION--------------------
            currentHealth += health;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }

    public void TakeDamage(float damage) //deal damage to player
    {
        if (damage > 0)
        {
            animator.SetTrigger("PlayerHurt");
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    public void Stun(float duration) //stun enemy for set time
    {
        if (duration > 0)
        {
            //--------------------ADD SCRIPT TO TRIGGER ANIMATION--------------------
            stunDuration = duration;
        }
    }

    public void EndStun() //end stun effect
    {
        stunDuration = 0;
    }

    void Die() //kill enemy
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
