using System.Collections;
using System.Collections.Generic;
using Luke;
using Matthew;
using UnityEngine;

namespace Zach
{
    public class UIHiddenState : IState
    {
        StateEventTransitionSubscription subscription_openNote;



        public void OnEnter(IContext context)
        {
            var uiState = (context as UIContext).Behaviour;
            uiState.SetJournalActive(false);
            uiState.SetNoteActive(false);
            uiState.SetButtonActove(false);
            subscription_openNote = new StateEventTransitionSubscription
            {
                Subscribeable = Resources.Load("Events/OpenNote") as GameEvent
            };

        }

        public void OnExit(IContext context)
        {
            subscription_openNote.UnSubscribe();
            Debug.Log("close note?");
            
            
        }

        public void UpdateState(IContext context)
        {
            if (subscription_openNote.EventRaised)
            {
                context.ChangeState(new UINoteState());
                Debug.Log("open note?");
                return;
            }
            if (Zach.PlayerInput.PausePressed)
            {
                context.ChangeState(new UIJournalState());
                return;
            }

        }
    }
}