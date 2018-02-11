using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberManMove : MonoBehaviour
{
    public float moveSpeed = 5;
    private Animator animator;
    private Rigidbody2D body;
    const string Position = "Position";
    const string Walk = "Walk";

    void Awake()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (Input.GetKey("up"))
        {
            body.velocity = new Vector2(0, moveSpeed);

            animator.SetBool(Walk, true);
            animator.SetInteger(Position, 0);
        }
        else if (Input.GetKey("right"))
        {
            body.velocity = new Vector2(moveSpeed, 0);

            animator.SetBool(Walk, true);
            animator.SetInteger(Position, 1);

        }
        else if (Input.GetKey("down"))
        {
            body.velocity = new Vector2(0, -moveSpeed);

            animator.SetBool(Walk, true);
            animator.SetInteger(Position, 2);
        }
        else if (Input.GetKey("left"))
        {
            body.velocity = new Vector2(-moveSpeed, 0);
            
            animator.SetBool(Walk, true);
            animator.SetInteger(Position, 3);
        }
        else
        {
            animator.SetBool(Walk, false);
            body.velocity = Vector2.zero;
        }
    }
}
