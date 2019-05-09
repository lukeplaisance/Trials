using System.Collections;
using System.Collections.Generic;
using Luke;
using UnityEngine;

public class PushPullPatch : MonoBehaviour
{
    public PushPullBehaviour block;
    public bool isFrontCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Grabbable") || other.CompareTag("Waypoint"))
            return;
        if(isFrontCollider)
            block.isFrontColliding = true;
        else
            block.isBackColliding = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Grabbable") || other.CompareTag("Waypoint"))
            return;
        if (isFrontCollider)
            block.isFrontColliding = false;
        else
            block.isBackColliding = false;
    }

}
