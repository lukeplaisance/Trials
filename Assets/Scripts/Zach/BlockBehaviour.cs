using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour, IGrabbable
{
    bool Grabbed = false;
    Transform grabTrans;

    public void GetDropped()
    {
        Grabbed = false;
        var box = GetComponent<BoxCollider>();
        box.enabled = true;
    }

    public void GetGrabbed(Transform trans)
    {
        Grabbed = true;
        var box = GetComponent<BoxCollider>();
        box.enabled = false;
        grabTrans = trans;        
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		if(Grabbed)
        {
            transform.position = grabTrans.position;
        }
	}
}
