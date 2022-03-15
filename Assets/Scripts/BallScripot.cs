using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScripot : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            BallCollector bc = other.attachedRigidbody.gameObject.GetComponent<BallCollector>();
            if (bc != null)
            {
                bc.receiveBall();
                Destroy(this.gameObject);
            }
        }
    }


}
