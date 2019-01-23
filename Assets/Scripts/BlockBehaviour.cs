using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour, IGrabbable
{
    bool Grabbed = false;
    Vector3 grabPos;
    public void GetGrabbed(Vector3 position)
    {
        Grabbed = !Grabbed;
        grabPos = position;
        this.transform.position = position;
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
