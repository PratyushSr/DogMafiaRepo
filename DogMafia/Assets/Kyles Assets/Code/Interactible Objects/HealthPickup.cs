using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float health;
    public GameObject deathEffect;
    // Start is called before the first frame update

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        //Will_Movement player = hitInfo.GetComponent<Will_Movement>();
        if (hitInfo.gameObject.CompareTag("Player")) //if (hitInfo != null)
        {
           // player.GetHealth(health);
            Debug.Log("Player healed 100 health");
            Die();
        }
    }
    void Die()
    {
        if(deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
