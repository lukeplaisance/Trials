using Luke;
using Matthew;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zach
{
    public class UINoteState : IState
    {
        StateEventTransitionSubscription subscription_journal;
        StateEventTransitionSubscription subscription_noUI;
        StateEventTransitionSubscription subscription_closeNote;

        public void OnEnter(IContext context)
        {
            var uiState = (context as UIContext).Behaviour;
            uiState.SetJournalActive(false);
            uiState.SetNoteActive(true);
            subscription_noUI = new StateEventTransitionSubscription
            {
                Subscribeable = Resources.Load("Events/OpenNote") as GameEvent
            };

            subscription_closeNote = new StateEventTransitionSubscription
            {
                Subscribeable = Resources.Load("Events/CloseNote") as GameEvent
            };

            subscription_journal = new StateEventTransitionSubscription
            {
                Subscribeable = Resources.Load("Events/OpenPauseMenu") as GameEvent
            };
            
        }

        public void OnExit(IContext context)
        {
            subscription_noUI.UnSubscribe();
            subscription_journal.UnSubscribe();
        }

        public void UpdateState(IContext context)
        {
            if (subscription_noUI.EventRaised)
            {
                context.ChangeState(new PlayerPauseState());
            }

            if (subscription_closeNote.EventRaised)
            {
                context.ChangeState(new UIJournalState());
            }
        }
    }
}