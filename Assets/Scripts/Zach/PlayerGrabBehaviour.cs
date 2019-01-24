using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabBehaviour : MonoBehaviour, IGrabber
{
    public Transform grabbedObjectPos;
    bool ObjectGrabbed = false;
    public GameObject block;
    IGrabber graber;
    IGrabbable grabit;

    public void Grab(IGrabbable grabbable)
    {
        grabbable.GetGrabbed(grabbedObjectPos);
    }

    public void Drop(IGrabbable grabbable)
    {
        grabbable.GetDropped();
    }

    // Use this for initialization
    void Start ()
    {
        graber = GetComponent<IGrabber>();
        grabit = block.GetComponent<IGrabbable>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown("Fire1"))
            ObjectGrabbed = !ObjectGrabbed;

        if (ObjectGrabbed)
            Grab(grabit);
        else
            Drop(grabit);
	}

    
}
