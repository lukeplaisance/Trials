using Luke;
using Matthew;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zach
{
    public class UIJournalState : IState
    {
        StateEventTransitionSubscription subscription_noUI;
        StateEventTransitionSubscription subscription_note;

        public void OnEnter(IContext context)
        {
            var uiState = (context as UIContext).Behaviour;
            uiState.SetJournalActive(true);
            uiState.SetNoteActive(false);
            subscription_note = new StateEventTransitionSubscription
            {
                Subscribeable = Resources.Load("Events/OpenNote") as GameEvent
            };
            subscription_noUI = new StateEventTransitionSubscription
            {
                Subscribeable = Resources.Load("Events/ClosePauseMenu") as GameEvent
            };
        }

        public void OnExit(IContext context)
        {
            subscription_note.UnSubscribe();
            subscription_noUI.UnSubscribe();
        }

        public void UpdateState(IContext context)
        {
            if (subscription_note.EventRaised)
            {
                context.ChangeState(new UINoteState());
            }

            if (subscription_noUI.EventRaised)
            {
                context.ChangeState(new UINoUIState());
            }
        }
    }
}