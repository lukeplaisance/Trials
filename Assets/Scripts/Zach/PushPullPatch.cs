using System.Collections;
using System.Collections.Generic;
using Luke;
using UnityEngine;

public class PushPullPatch : MonoBehaviour
{
    public PushPullBehaviour block;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Grabbable"))
            return;
        block.isColliding = true;
    }

}
