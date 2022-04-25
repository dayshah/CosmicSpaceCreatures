using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
