namespace Matthew
{
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
            if (UnityEngine.Input.GetButtonDown("Pause"))
            {
                context.ChangeState(new PlayerIdleState());
            }

        }
    }
}