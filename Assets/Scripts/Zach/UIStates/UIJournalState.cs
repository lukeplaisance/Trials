using Luke;
using Matthew;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zach
{
    public class UIJournalState : IState
    {
        StateEventTransitionSubscription subscription_closePauseMenu;
        StateEventTransitionSubscription subscription_openNote;

        public void OnEnter(IContext context)
        {
            var uiState = (context as UIContext).Behaviour;
            uiState.SetJournalActive(true);
            uiState.SetNoteActive(false);
            subscription_openNote = new StateEventTransitionSubscription
            {
                Subscribeable = Resources.Load("Events/OpenNote") as GameEvent
            };
            subscription_closePauseMenu = new StateEventTransitionSubscription
            {
                Subscribeable = Resources.Load("Events/ClosePauseMenu") as GameEvent
            };
        }

        public void OnExit(IContext context)
        {
            subscription_openNote.UnSubscribe();
            subscription_closePauseMenu.UnSubscribe();
        }

        public void UpdateState(IContext context)
        {
            if (subscription_openNote.EventRaised)
            {
                context.ChangeState(new UINoteState());
            }

            if (subscription_closePauseMenu.EventRaised)
            {
                context.ChangeState(new UIHiddenState());
            }
        }
    }
}