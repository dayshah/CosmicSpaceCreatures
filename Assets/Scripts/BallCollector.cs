using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool hasBall = false;
    public bool hit = false;
    public void receiveBall()
    {
        hasBall = true;
    }
    public void hitObstacleCollider()
    {
        hit = true;
    }
    public void outOfCollider()
    {
        hit = false;
    }
}
