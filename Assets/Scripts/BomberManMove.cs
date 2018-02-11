using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberManMove : MonoBehaviour
{

    private Animator animator;
    const string Position = "Position";
    const string Walk = "Walk";

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            animator.SetBool(Walk, true);
            animator.SetInteger(Position, 0);
        }
        else if (Input.GetKey("right"))
        {
            animator.SetBool(Walk, true);
            animator.SetInteger(Position, 1);

        }
        else if (Input.GetKey("down"))
        {
            animator.SetBool(Walk, true);
            animator.SetInteger(Position, 2);
        }
        else if (Input.GetKey("left"))
        {
            animator.SetBool(Walk, true);
            animator.SetInteger(Position, 3);
        }
        else
        {
            animator.SetBool(Walk, false);
        }
    }
}
