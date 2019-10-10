using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public float currentHealth; //current health
    public float maxHealth; //current health will not exceed this number
    public GameObject deathEffect; //create game object on death
    public float speed; //speed of enemy
    public float stoppingDistance; //how much distance will keep between player
    public float retreatDistance; //how close the player has to get to back away

    private float timeBtwShots; //shot counter
    public float shotFreq; //time between shots
    public float range; //minimum distance required to shoot at player

    private float stunDuration;

    public GameObject projectile; //projectile the enemy shoots
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        if (currentHealth <= 0) //if health is set to zero, die
        {
            Die();
        }

        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = shotFreq;

        stunDuration = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (stunDuration <= 0) //if enemy is stunned, disable all updating scripts for set time
        {
            //--------------------ADD SCRIPT TO END STUN ANIMATION--------------------
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance) //if enemy is certaon distance away, move closer
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            }
            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance) //stay put
            {
                transform.position = this.transform.position;

            }
            else if (Vector2.Distance(transform.position, player.position) < retreatDistance) //if player is within retreat distance, run away
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }

            if (timeBtwShots <= 0) //is able to shoot
            {
                if (Vector2.Distance(transform.position, player.position) <= range) //is within range to shoot
                {
                    Instantiate(projectile, transform.position, Quaternion.identity); 
                    timeBtwShots = shotFreq; 
                }
            }
            else
            {
                timeBtwShots -= Time.deltaTime; 
            }
        }
        else //if stunDuration is greater than 0, count down 
        {
            stunDuration -= Time.deltaTime;
        }
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

    void Die() //kill enemy
    {
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
                