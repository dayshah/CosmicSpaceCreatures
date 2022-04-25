using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    Animator animator;
    private GameObject target;
    private Vector3 offset;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        animator.SetBool("BallCollectorHere", true);
        target = null;

    }
    void Update()
    {
    }

    void OnTriggerStay(Collider c)
    {
        target = c.gameObject;
        offset = target.transform.position - transform.position;
    }
    void OnTriggerExit(Collider c)
    {
        target = null;
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            target.transform.position = transform.position + offset;
        }
    }
}
