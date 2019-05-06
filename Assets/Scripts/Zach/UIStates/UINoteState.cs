using Luke;
using Matthew;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zach
{
    public class UINoteState : IState
    {
        StateEventTransitionSubscription subscription_openPauseMenu;
        StateEventTransitionSubscription subscription_closePauseMenu;
        StateEventTransitionSubscription subscription_closeNote;

        public void OnEnter(IContext context)
        {
            var uiState = (context as UIContext).Behaviour;
            uiState.SetJournalActive(false);
            uiState.SetNoteActive(true);
            Debug.Log("note book interaction scotty");
            FMODUnity.RuntimeManager.PlayOneShot("event:/notebook_selection");
            subscription_closePauseMenu = new StateEventTransitionSubscription
            {
                Subscribeable = Resources.Load("Events/ClosePauseMenu") as GameEvent
            };

            subscription_closeNote = new StateEventTransitionSubscription
            {
                Subscribeable = Resources.Load("Events/CloseNote") as GameEvent
            };

            subscription_openPauseMenu = new StateEventTransitionSubscription
            {
                Subscribeable = Resources.Load("Events/OpenPauseMenu") as GameEvent
            };

        }

        public void OnExit(IContext context)
        {
            subscription_closePauseMenu.UnSubscribe();
            subscription_closeNote.UnSubscribe();
            subscription_openPauseMenu.UnSubscribe();
            //FMODUnity.RuntimeManager.PlayOneShot("event:/hazard_hallway_sliding_doors");

        }

        public void UpdateState(IContext context)
        {

            if (PlayerInput.CancelPressed)
            {
                context.ChangeState(new UIHiddenState());
                return;
            }

            if (subscription_closeNote.EventRaised)
            {
                context.ChangeState(new UIJournalState());
                Debug.Log("CLOSE NOTEBOOK");
                FMODUnity.RuntimeManager.PlayOneShot("event:/notebook_close");
            }
        }
    }
}
