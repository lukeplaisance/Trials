using System.Collections;
using System.Collections.Generic;
using Luke;
using Matthew;
using UnityEngine;

namespace Zach
{
    public class UIHiddenState : IState
    {
        StateEventTransitionSubscription subscription_openPauseMenu;
        StateEventTransitionSubscription subscription_openNote;
        public void OnEnter(IContext context)
        {
            var uiState = (context as UIContext).Behaviour;
            uiState.SetJournalActive(false);
            uiState.SetNoteActive(false);
            subscription_openNote = new StateEventTransitionSubscription
            {
                Subscribeable = Resources.Load("Events/OpenNote") as GameEvent
            };
            subscription_openPauseMenu = new StateEventTransitionSubscription
            {
                Subscribeable = Resources.Load("Events/OpenPauseMenu") as GameEvent
            };
        }

        public void OnExit(IContext context)
        {
            subscription_openNote.UnSubscribe();
            subscription_openPauseMenu.UnSubscribe();
        }

        public void UpdateState(IContext context)
        {
            if (subscription_openNote.EventRaised)
            {
                context.ChangeState(new UINoteState());
            }
            if (Input.GetButtonDown("Pause") || subscription_openPauseMenu.EventRaised)
            {
                context.ChangeState(new UIJournalState());
            }

        }
    }
}