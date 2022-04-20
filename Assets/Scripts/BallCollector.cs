using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallCollector : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (balls == 2)
        {
            SceneManager.LoadScene("EndGame");
        }
    }

    public bool hasBall = false;
    public bool hit = false;
    public int balls = 0;
    public void receiveBall()
    {
        hasBall = true;
        balls += 1;
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
