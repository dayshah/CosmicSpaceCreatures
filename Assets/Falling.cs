using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public Jumping myJumping;
    void OnCollisionExit()
    {
        myJumping.isFalling = true;
    }

    void OnCollisionEnter()
    {
        myJumping.isFalling = false;
    }

    void Update()
    {
        if (myJumping.isFalling)
        {
            myJumping.CheckIfCanJump();
        }
    }
}
