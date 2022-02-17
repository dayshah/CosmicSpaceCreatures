using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    Animator animator;
    public bool wPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool wBool = Input.GetKey("w");
        bool shiftBool = Input.GetKey("left shift");
        bool spaceBool = Input.GetKey("space");
        if (wBool && shiftBool)
        {
            wPressed = true;
            animator.SetBool("walking", true);
            animator.SetBool("running", true);
        }
        else if (wBool) {
            animator.SetBool("walking", true);
            animator.SetBool("running", false);
        }
        else
        {
            wPressed = false;
            animator.SetBool("walking", false);
            animator.SetBool("running", false);
        }
        if (Input.GetKeyUp("space"))
        {
            animator.SetTrigger("jumping");
        }
    }
}
