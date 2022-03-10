using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayerMovement : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float vert = Input.GetAxis("Vertical") * speed;
        float horiz = Input.GetAxis("Horizontal") * speed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        vert *= Time.deltaTime;
        horiz *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(horiz, 0, vert);
    }
}
