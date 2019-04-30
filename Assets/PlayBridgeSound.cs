using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBridgeSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayOnesShotBridgeSound()
    {
        Debug.Log("bridge sound should play");
        //FMODUnity.RuntimeManager.PlayOneShot("event:/bridge_lowering_sound");
    }
}
