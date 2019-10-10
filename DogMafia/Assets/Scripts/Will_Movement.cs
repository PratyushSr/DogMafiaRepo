using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Will_Movement : MonoBehaviour
{
    public Rigidbody2D rbody;
    public float speed;
    public Animator anim;
    public VectorValue startingPosition;

    void Start()
    {
        transform.position = startingPosition.initialValue;
    }
    
    public bool stopMovement()
    {
        bool inAction;
        if (DialogueManager.instance.inDialogue)
        {
            inAction = true;
        }
        else
        {
            inAction = false;
        }

        return inAction;
    }

    private void Update()
    {   if (stopMovement()) return;
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (movement != Vector2.zero)
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("input_x", movement.x);
            anim.SetFloat("input_y", movement.y);
        }

        else
        {
            anim.SetBool("isWalking", false);
        }

        rbody.MovePosition(rbody.position + movement * Time.deltaTime * speed);
    }
}
