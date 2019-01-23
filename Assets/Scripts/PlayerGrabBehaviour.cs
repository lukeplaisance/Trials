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
        grabbable.GetGrabbed(grabbedObjectPos.position);
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
        {
            Grab(grabit);
            ObjectGrabbed = !ObjectGrabbed;
        }
	}
}
