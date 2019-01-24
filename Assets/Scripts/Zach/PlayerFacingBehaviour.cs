using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFacingBehaviour : MonoBehaviour
{
    public Camera cam;
	void Start ()
    {
		
	}
	
	void Update ()
    {
        transform.forward = new Vector3(cam.transform.forward.x,transform.forward.y,cam.transform.forward.z);
	}
}
