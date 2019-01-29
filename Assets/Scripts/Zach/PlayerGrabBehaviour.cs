using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabBehaviour : MonoBehaviour, IGrabber
{
    public Transform grabbedObjectPos;
    private BlockBehaviour grabit;
    bool ObjectGrabbed = false;

    public void Grab(IGrabbable grabbable)
    {
        grabbable.GetGrabbed(grabbedObjectPos);
    }

    public void Drop(IGrabbable grabbable)
    {
        grabbable.GetDropped();
    }

    // Use this for initialization
	
	// Update is called once per frame
	void Update ()
    {
        RaycastHit hit;
        if (Input.GetButtonDown("Fire1") && ObjectGrabbed)
        {
            Drop(grabit);
            grabit = null;
            ObjectGrabbed = false;
        }
        else if (Physics.Raycast(transform.position, transform.forward, out hit,5))
        {
            if(hit.collider.gameObject.tag == "Grabbable" && Input.GetButtonDown("Fire1"))
            {
                if (!ObjectGrabbed)
                {
                    grabit = hit.collider.gameObject.GetComponent<BlockBehaviour>();
                    Grab(grabit);
                    ObjectGrabbed = true;
                }
                    
            }
            
        }
        
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * 5);
    }
}
