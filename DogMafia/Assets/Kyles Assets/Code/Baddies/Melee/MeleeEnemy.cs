using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    //defined variables
    public float currentHealth; //current health
    public float maxHealth; //current health will not go above this value
    public GameObject deathEffect; //effect on death
    public float speed; //how fast the enemy is gonna move
    public float range; //range of melee attack
    public float stoppingDistance; //AI will stop this distance away from the player
    public float attackFreq; //how fast the enemy attacks
    public float attkDmg; //damage of attack


    private float attackCounter;
    private Transform player; //target of AI/player
    private float stunDuration; //duration of stun


    void Start()
    {
        if(currentHealth <= 0)
        {
            Die();
        }
        player = GameObject.FindGameObjectWithTag("Player").transform;
        stunDuration = 0;
        attackCounter = attackFreq;
    }

    void Update()
    {
        if (stunDuration <= 0)
        {
            //--------------------ADD SCRIPT TO END STUN ANIMATION--------------------
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance) //only makes the enenmy move towards the player when a certain distance away
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime); //moves the enemy towards the player
            }
            if (attackCounter <= 0) //is able to shoot
            {
                if (Vector2.Distance(transform.position, player.position) <= range) //is within range to shoot
                {
                    Attack();
                    attackCounter = attackFreq;
                }
            }
            else
            {
                attackCounter -= Time.deltaTime;
            }
        }
        else
        {
            stunDuration -= Time.deltaTime;
        }
    }

    void Attack()
    {
        PlayerHealth plr = player.GetComponent<PlayerHealth>();
        plr.TakeDamage(attkDmg);
        Debug.DrawRay(transform.position, player.position - transform.position, Color.red, 1f);
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

    public void TakeDamage(float damage) //deal damage to enemy
    {
        if (damage > 0)
        {
            //--------------------ADD SCRIPT TO TRIGGER ANIMATION--------------------
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

    public void Die() //kill enemy
    {
        if(deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
