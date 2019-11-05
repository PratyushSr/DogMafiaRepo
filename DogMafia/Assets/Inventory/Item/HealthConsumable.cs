using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Health Consumable", menuName = "Items/Consumable", order = 1)]
public class HealthConsumable : Item, IUseable
{
    public Sprite myIcon { get; }
    [SerializeField]
    private int healthValue;

    private PlayerHealth health;
    private GameObject player;

    public void Use()
    {
        Remove();
        //Will_Movement.health.MyCurrentValue += healthValue;
        //must integrate playerhealth and health bar
//        player = GameObject.Find("Player");
//        player.GetComponent<PlayerHealth>().Heal(healthValue);

    }
}
