using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Luke;

public class LOCKCAMERABEHAVIOUR : MonoBehaviour
{
    public GameObject lockCam;
    public GameObject otherCam;
    public NewPlayerMovementBehaviour player;
    public CombinationLockBehaviour combo_lock;
	// Use this for initialization
	void Start ()
    {
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(combo_lock.isLocked == false)
        {
            lockCam.active = false;
            otherCam.active = true;
            player.IsFrozen = false;
            Cursor.visible = false;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            lockCam.active = true;
            otherCam.active = false;
            Cursor.visible = true;
            player.IsFrozen = true;
            Cursor.visible = true;
        }
    }
}
