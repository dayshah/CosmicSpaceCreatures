using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]

public class ThrowScript : MonoBehaviour
{
    private Transform handHold;
    public Rigidbody ballPrefab;
    private Animator anim;
    private Rigidbody currBall;
    public int creaturesCaptured;
    public Rigidbody player;

    void Awake()
    {
        currBall = null;
        anim = GetComponent<Animator>();

        // go back to fix step 23
        handHold = this.transform.Find("Root/Hips/Spine_01/Spine_02/Spine_03/Clavicle_L/Shoulder_L/Elbow_L/Hand_L/BallHoldSpot");

        if (ballPrefab == null)
        {
            throw new System.Exception("ball prefab is null");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        creaturesCaptured = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("Throw", true);
        } else
        {
            if (this.anim.GetCurrentAnimatorStateInfo(1).IsName("Throwing"))
            {
                anim.SetBool("Throw", false);
            }
        }

        if (creaturesCaptured == 2)
        {
            SceneManager.LoadScene("EndGame");
        }
    }

    private void ThrowBall()
    {
        //Debug.Log(handHold);
        currBall = Instantiate<Rigidbody>(ballPrefab, handHold);
        
        currBall.transform.localPosition = Vector3.zero;
        currBall.isKinematic = true;
        currBall.transform.parent = null;
        currBall.isKinematic = false;
        currBall.velocity = Vector3.zero;
        currBall.angularVelocity = Vector3.zero;

        Vector3 forceDir = this.transform.forward;
        forceDir.y = 0.8f;
        currBall.AddForce(50 * forceDir, ForceMode.Impulse);
        currBall = null;
    }

    public void setFalse() 
    {
        anim.SetBool("Throw", false);
    }

    

    public void CaptureCreature()
    { 
        creaturesCaptured++;
        //Debug.Log("CREATURE CAPTURED: " + creaturesCaptured);
    }
}
