using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth; 
    public GameObject deathEffect;
    private float stunDuration;
    public RangedEnemy rg;


    // Start is called before the first frame update
    void Start()
    {
        if(currentHealth <= 0)
        {
            Die();
        }
        stunDuration = 0;
    }

    public void GetHealth(float health)
    {
        if (health > 0)
        {
            currentHealth += health;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }
    public void TakeDamage(float damage)
    {
        if (damage > 0)
        {
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
            rg.Stun(5);
            stunDuration = duration;
        }
    }

    public void EndStun() //end stun effect
    {
        stunDuration = 0;
    }

    void Die()
    {
        if(deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
