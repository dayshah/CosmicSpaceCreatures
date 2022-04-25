using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBridge : MonoBehaviour
{

    public GameObject bridge;

    // Start is called before the first frame update
    void Start()
    {
        bridge.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player")) {
            bridge.SetActive(true);
        }
    }
}
