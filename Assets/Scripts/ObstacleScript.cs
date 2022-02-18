using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = this.GetComponent<Animator>();
    }
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            BallCollector bc = other.attachedRigidbody.gameObject.GetComponent<BallCollector>();
            if (bc != null)
            {
                animator.SetBool("BallCollectorHere", true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            BallCollector bc = other.attachedRigidbody.gameObject.GetComponent<BallCollector>();
            if (bc != null)
            {
                animator.SetBool("BallCollectorHere", false);
            }
        }
    }
}
