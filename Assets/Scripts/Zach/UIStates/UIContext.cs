using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zach
{
    public class UIContext : IContext
    {
        public UIStateBehaviour Behaviour { get; set; }
        private IState _currentState;

        public NoteBehaviour noteBehaviour;
        private FMOD.Studio.EventInstance voiceOver;
        FMOD.Studio.PLAYBACK_STATE VoiceOverPlaybackState;
        private GameObject Note1;

        void Start()
        {
            Note1 = GameObject.Find("Note");
            Debug.Log(Note1);
            noteBehaviour = Note1.GetComponent<NoteBehaviour>();
            voiceOver = noteBehaviour.VoiceOver;
            Debug.Log(voiceOver);
            
        }

        void Update()
        {
            voiceOver.getPlaybackState(out VoiceOverPlaybackState);
            Debug.Log(VoiceOverPlaybackState);
        }

        public IState CurrentState
        {
            get { return _currentState; }
            set
            {
                _currentState = value;
                _currentState.OnEnter(this);
            }
        }

        public void ChangeState(IState next)
        {
            Debug.Log(string.Format("{0} -> {1}", CurrentState, next));
            CurrentState.OnExit(this);
            CurrentState = next;
            CurrentState.OnEnter(this);

            Debug.Log("close whole notebook");
            FMODUnity.RuntimeManager.PlayOneShot("event:/notebook_close");

            //Debug.Log(VoiceOverPlaybackState);
            //if (VoiceOverPlaybackState == FMOD.Studio.PLAYBACK_STATE.PLAYING)
            //{
            //    voiceOver.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            //}
        }

        public void ResetContext()
        {
            _currentState = new UIHiddenState();
            _currentState.OnEnter(this);
        }

        public void UpdateContext()
        {
            _currentState.UpdateState(this);
        }
    }
}
