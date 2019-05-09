namespace Matthew
{
    public class PlayerPauseState : IState
    {
        StateEventTransitionSubscription listener;
        public void OnEnter(IContext context)
        {
            var playerbehaviour = (context as PlayerContext).Behaviour;
            playerbehaviour.SetMovement(false);
            playerbehaviour.SetCamera(false);
            listener = new StateEventTransitionSubscription
            {
                Subscribeable = UnityEngine.Resources.Load("Events/ClosePauseMenu") as Luke.GameEvent
            };
        }
 

        public void OnExit(IContext context)
        {
            var playerbehaviour = (context as PlayerContext).Behaviour;
            playerbehaviour.SetMovement(true);
            playerbehaviour.SetCamera(true);
            
        }

        public void UpdateState(IContext context)
        {            
            if (Zach.PlayerInput.CancelPressed)
            {
                if((context as PlayerContext).Behaviour.CurrentInteraction != null)
                {
                    context.ChangeState(new PlayerInteractState());
                    return;
                }
                    
                context.ChangeState(new PlayerIdleState());
                return;
            }

        }
    }
}