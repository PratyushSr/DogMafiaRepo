using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public GameObject respawnPoint;
    public GameObject deathEffect;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        if(currentHealth <= 0)
        {
            Die();
        }
        healthBar.UpdateHealth();
    }

    public void Heal(float health)
    {
        if(health > 0)
        {
            currentHealth += health;
            if(currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
        healthBar.UpdateHealth();
    }

    public void TakeDamage(float damage)
    {
        if(damage > 0)
        {
            currentHealth -= damage;
        }
        if(currentHealth <= 0)
        {
            Die();
        }
        else
        {
            healthBar.UpdateHealth();
        }
    }
    
    void PermaDie()
    {
        if(deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
    

    void Die()
    {
        if(respawnPoint == null)
        {
            PermaDie();
        }
        transform.position = respawnPoint.transform.position;
        currentHealth = maxHealth;
        healthBar.UpdateHealth();
    }
}
