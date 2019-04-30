using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour 
{
    [FMODUnity.EventRef]
    FMOD.Studio.EventInstance MusicInst;

void Start () 
    {
        MusicInst = FMODUnity.RuntimeManager.CreateInstance("event:/gameplay_music");
        MusicInst.start();
        MusicInst.release();
        	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnDestroy()
    {
        MusicInst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
