namespace Matthew
{
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
            listener.UnSubscribe();

        }

        public void UpdateState(IContext context)
        {
            if (listener.EventRaised)
                context.ChangeState(new PlayerIdleState());
            if (UnityEngine.Input.GetButtonDown("Cancel"))
                context.ChangeState(new PlayerIdleState());

        }
    }
}