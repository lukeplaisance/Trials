
namespace Matthew
{
    public class PlayerIdleState : IState
    {
        StateEventTransitionSubscription subscription_interaction;
        StateEventTransitionSubscription subscription_pause;
        StateEventTransitionSubscription subscription_noteInteract;
        public void OnEnter(IContext context)
        {
            subscription_interaction= new StateEventTransitionSubscription { 
                Subscribeable = UnityEngine.Resources.Load("Events/InteractionStart") as Luke.GameEvent
            };

            subscription_pause = new StateEventTransitionSubscription
            {
                Subscribeable = UnityEngine.Resources.Load("Events/OpenPauseMenu") as Luke.GameEvent
            };

            subscription_noteInteract = new StateEventTransitionSubscription
            {
                Subscribeable = UnityEngine.Resources.Load("Events/NoteInteraction") as Luke.GameEvent
            };


        }

        public void OnExit(IContext context)
        {
            subscription_interaction.UnSubscribe();
            subscription_pause.UnSubscribe();
            subscription_noteInteract.UnSubscribe();
        }

        public void UpdateState(IContext context)
        {
            var playercontext = (PlayerContext) context;

            if(UnityEngine.Input.GetButtonDown("Pause"))
            {
                context.ChangeState(new PlayerPauseState());
            }
            if (subscription_interaction.EventRaised)
            {
                context.ChangeState(new PlayerInteractState());
            }
            
            if (subscription_noteInteract.EventRaised)
            {
                context.ChangeState(new PlayerPauseState());
            }
        }
    }
}