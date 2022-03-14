using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] 
public class CharacterController : MonoBehaviour
{

    Animator animator;
    public bool wPressed = false;
    public Vector3 jump;
    public float jumpForce = 2.0f;

    public bool isGrounded;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay(){
        isGrounded = true;
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

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            animator.SetTrigger("jumping");
            animator.Play("Jump");
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
