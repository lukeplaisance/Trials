using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOCKCAMERABEHAVIOUR : MonoBehaviour
{
    public GameObject lockCam;
    public GameObject otherCam;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            lockCam.active = true;
            otherCam.active = false;
            Cursor.visible = true;
        }
    }
}
