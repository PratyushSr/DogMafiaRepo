using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject primaryAttack;
    public GameObject secondaryAttack;
    public Will_Movement wm;
    public Animator animator;

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (wm.stopMovement() == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                animator.SetTrigger("Attack");
                ShootPrimary();

            }
            else if (Input.GetButtonDown("Fire2"))
            {
                ShootSecondary();
            }
        }
    }

    void ShootPrimary()
    {
        if(primaryAttack != null)
        {
            Instantiate(primaryAttack, firePoint.position, firePoint.rotation);
        }
    }
    void ShootSecondary()
    {
        if(secondaryAttack != null)
        {
            Instantiate(secondaryAttack, firePoint.position, firePoint.rotation);
        }
    }
}
