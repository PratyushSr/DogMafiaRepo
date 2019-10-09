using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public GameObject deathEffect;
    // Start is called before the first frame update
    void Start()
    {
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        if(damage > 0)
        {
            currentHealth -= damage;
            if(currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
