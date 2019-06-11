using System.Collections;
using System.Collections.Generic;
using Luke;
using UnityEngine;
using UnityEngine.UI;
using Matthew;

namespace Zach
{
    public class NoteBehaviour : MonoBehaviour
    {
        public StringVariable NoteTextStringVariable;
        public AudioVariable NoteAudioVariable;
        public GameEvent NoteInteract;
        public GameObjectVariable NoteUI;
        public NoteScriptable note;



        public FMOD.Studio.EventInstance VoiceOver;
        FMOD.Studio.PLAYBACK_STATE VoiceOverPlaybackState;

        public void Start()
        {
            VoiceOver = FMODUnity.RuntimeManager.CreateInstance("event:/Note1_Voiceover");            
        }

        public void Update()
        {
            VoiceOver.getPlaybackState(out VoiceOverPlaybackState);            
        }        

        public void OnInteract()
        {
            NoteTextStringVariable.Value = note.noteName;
            NoteTextStringVariable.MaxValue = note.data;
            NoteAudioVariable.Value = note.narration;
            note.SetIsEnabled(true);
            NoteInteract.Raise();
            FMODUnity.RuntimeManager.PlayOneShot("event:/notebook_open");
            VoiceOver.start();
        }

        public void OnNoteClosed()
        {
            if (VoiceOverPlaybackState == FMOD.Studio.PLAYBACK_STATE.PLAYING)
            {
               VoiceOver.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            }
        }
    }
}