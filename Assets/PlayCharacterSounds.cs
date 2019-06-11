using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCharacterSounds : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void PlayOneShotStoneFootstep()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/general_stone_footstep");
    }
}
