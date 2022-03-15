using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        animator.SetBool("BallCollectorHere", true);

    }
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

}
