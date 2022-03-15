using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    public float jumpForce;
    public bool canJump;
    public float leniencey;
    public bool isFalling;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        jumpForce = 500.0f;
        leniencey = 0.2f;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("jump");
            CheckIfCanJump();

            if (canJump)
            {
                canJump = false;
                Vector3 jump = new Vector3(0f, 1.0f, 0f);
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                
            }
        }
    }

    public void CheckIfCanJump()
    {
        RaycastHit hit;
        Ray landingRay = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(transform.position, Vector3.down * leniencey);

        if (Physics.Raycast(landingRay, out hit, leniencey))
        {
            Debug.Log(hit.collider);
            if (hit.collider == null)
            {
                canJump = false;
            }
            else
            {
                canJump = true;
            }
        }
    }
    
}
