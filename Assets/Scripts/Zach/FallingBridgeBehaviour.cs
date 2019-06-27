using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBridgeBehaviour : MonoBehaviour
{
    public float timer;
    public WaitAndRespondBehaviour wr;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            wr.WaitAndRespond(timer);
        }
    }
}
