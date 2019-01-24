using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour, IGrabbable
{
    bool Grabbed = false;
    Vector3 grabPos;

    public void GetDropped()
    {
        Grabbed = false;
    }

    public void GetGrabbed(Transform trans)
    {
        Grabbed = true;
        grabPos = trans.position;
        this.transform.position = trans.position;
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		if(Grabbed)
        {
            transform.position = grabPos;
        }
	}
}
