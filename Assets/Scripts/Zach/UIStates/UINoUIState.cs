using System.Collections;
using System.Collections.Generic;
using Luke;
using Matthew;
using UnityEngine;

namespace Zach
{
    public class UINoUIState : IState
    {
        StateEventTransitionSubscription subscription_journal;
        StateEventTransitionSubscription subscription_note;

        public void OnEnter(IContext context)
        {
            var uiState = (context as UIContext).Behaviour;
            uiState.SetJournalActive(false);
            uiState.SetNoteActive(false);
            subscription_note = new StateEventTransitionSubscription
            {
                Subscribeable = Resources.Load("Events/OpenNote") as GameEvent
            };
            subscription_journal = new StateEventTransitionSubscription
            {
                Subscribeable = Resources.Load("Events/OpenPauseMenu") as GameEvent
            };
        }

        public void OnExit(IContext context)
        {
            subscription_note.UnSubscribe();
            subscription_journal.UnSubscribe();
        }

        public void UpdateState(IContext context)
        {
            if (subscription_note.EventRaised)
            {
                context.ChangeState(new UINoteState());
            }

            if (subscription_journal.EventRaised)
            {
                context.ChangeState(new UIJournalState());
            }
        }
    }
}