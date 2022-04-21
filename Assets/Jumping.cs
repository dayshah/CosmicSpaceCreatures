using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    public float jumpForce;
    public float leniencey;
    private bool isJumpPressed;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        jumpForce = 500.0f;
        leniencey = 1f;
    }

    void OnCollisionEnter(Collision c)
    {
        foreach (ContactPoint cp in c.contacts)
        {
            if (Vector3.Dot(cp.normal, Vector3.up) > 0.5)
            {
                isGrounded = true;
                break;
            }
        }
        
    }

    void OnCollisionExit(Collision c)
    {
        if (!(c.gameObject.layer == 9))
        {
            isGrounded = false;
        }
        
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (isGrounded || CheckIfCanJump())
            {
                Debug.Log("Can Jump");
                Vector3 jump = new Vector3(0f, 1.0f, 0f);
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                isJumpPressed = false;
            }
            else
            {
                Debug.Log("Cannot Jump");
            }


        }
    }

    void FixedUpdate()
    {
        
    }

    public bool CheckIfCanJump()
    {
        RaycastHit hit;
        Ray landingRay = new Ray(transform.position, Vector3.down);
        //Debug.DrawRay(transform.position, Vector3.down * leniencey);

        if (Physics.Raycast(landingRay, out hit, leniencey))
        {
            return true;
        } else {
            return false;
        }

    }
    
}
