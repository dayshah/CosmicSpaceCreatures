using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    public float jumpForce;
    public float leniencey;
    public float footLeniencey;
    private bool isJumpPressed;
    private bool isGrounded;
    private AudioSource leftFootSound;
    private AudioSource rightFootSound;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] steps = GetComponents<AudioSource>();
        leftFootSound = steps[0];
        rightFootSound = steps[1];
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        jumpForce = 200.0f;
        leniencey = 1f;
        footLeniencey = 2f;
    }

    private void LeftFootNoise()
    {
        if (isGrounded || CheckIfFootstep())
        {
            leftFootSound.Play();
        }
        
    }

    private void RightFootNoise()
    {
        if (isGrounded || CheckIfFootstep())
        {
            rightFootSound.Play();
        }
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
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Trying to jump");
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

    public bool CheckIfFootstep()
    {
        RaycastHit hit;
        Ray landingRay = new Ray(transform.position, Vector3.down);
        //Debug.DrawRay(transform.position, Vector3.down * leniencey);

        if (Physics.Raycast(landingRay, out hit, footLeniencey))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

}
