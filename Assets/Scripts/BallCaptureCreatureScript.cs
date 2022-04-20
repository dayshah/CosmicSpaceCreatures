using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCaptureCreatureScript : MonoBehaviour
{
    public ThrowScript player_ref;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider c)
    {
        //Debug.Log(c.gameObject.layer);
        if (c.gameObject.layer == 8 && c.attachedRigidbody != null)
        {
            Destroy(c.attachedRigidbody.gameObject);
            player_ref.CaptureCreature();
        }
    }
}
