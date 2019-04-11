
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
}