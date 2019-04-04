
namespace Matthew
{
    public class PlayerIdleState : IState
    {
        StateEventTransitionSubscription subscription_interaction;
        StateEventTransitionSubscription subscription_pause;
        public void OnEnter(IContext context)
        {
            subscription_interaction= new StateEventTransitionSubscription { 
                Subscribeable = UnityEngine.Resources.Load("Events/InteractionStart") as Luke.GameEvent
            };

            subscription_pause = new StateEventTransitionSubscription
            {
                Subscribeable = UnityEngine.Resources.Load("Events/OpenPauseMenu") as Luke.GameEvent
            };
        }

        public void OnExit(IContext context)
        {
            subscription_interaction.UnSubscribe();
            subscription_pause.UnSubscribe();
        }

        public void UpdateState(IContext context)
        {
            if(subscription_pause.EventRaised)
            {
                context.ChangeState(new PlayerPauseState());
            }
            if(subscription_interaction.EventRaised)
            {
                context.ChangeState(new PlayerInteractState());
            }
        }
    }

    public class PlayerInteractState : IState
    {
        StateEventTransitionSubscription listener;
        public void OnEnter(IContext context)
        {
            var playerbehaviour = (context as PlayerContext).Behaviour;
            playerbehaviour.SetMovement(false);

            listener = new StateEventTransitionSubscription
            {
                Subscribeable = UnityEngine.Resources.Load("Events/InteractionStop") as Luke.GameEvent
            };
        }


        public void OnExit(IContext context)
        {
            var playerbehaviour = (context as PlayerContext).Behaviour;
            playerbehaviour.SetMovement(true);

        }

        public void UpdateState(IContext context)
        {
            if (listener.EventRaised)
                context.ChangeState(new PlayerIdleState());

        }
    }

    public class PlayerPauseState : IState
    {
        StateEventTransitionSubscription listener;
        public void OnEnter(IContext context)
        {
            var playerbehaviour = (context as PlayerContext).Behaviour;
            playerbehaviour.SetMovement(false);
            listener = new StateEventTransitionSubscription
            {
                Subscribeable = UnityEngine.Resources.Load("Events/ClosePauseMenu") as Luke.GameEvent
            };
        }
 

        public void OnExit(IContext context)
        {
            var playerbehaviour = (context as PlayerContext).Behaviour;
            playerbehaviour.SetMovement(true);
            
        }

        public void UpdateState(IContext context)
        {
            if (listener.EventRaised)
                context.ChangeState(new PlayerIdleState());

        }
    }
}