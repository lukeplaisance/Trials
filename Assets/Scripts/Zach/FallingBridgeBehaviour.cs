using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBridgeBehaviour : MonoBehaviour
{
    public float timer;
    public WaitAndRespondBehaviour wr;
    public BoxCollider bc;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bc.enabled = false;
            wr.WaitAndRespond(timer);
        }
    }
}
