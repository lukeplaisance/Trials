using Luke;
using UnityEngine;

namespace Matthew
{
    public class PlayerIdleState : IState
    {
        private StateEventTransitionSubscription _subscriptionInteractionStart;
        private StateEventTransitionSubscription _subscriptionPause;

        public void OnEnter(IContext context)
        {
            _subscriptionInteractionStart = new StateEventTransitionSubscription
            {
                Subscribeable = Resources.Load("Events/InteractionStart") as GameEvent
            };

            _subscriptionPause = new StateEventTransitionSubscription
            {
                Subscribeable = Resources.Load("Events/OpenPauseMenu") as GameEvent
            };
        }

        public void OnExit(IContext context)
        {
            _subscriptionInteractionStart.UnSubscribe();
            _subscriptionPause.UnSubscribe();
        }

        public void UpdateState(IContext context)
        {
            if (_subscriptionPause.EventRaised) context.ChangeState(new PlayerPauseState());
            if (_subscriptionInteractionStart.EventRaised) context.ChangeState(new PlayerInteractState());
        }
    }

    public class PlayerInteractState : IState
    {
        private StateEventTransitionSubscription _subscriptionStop;

        private float timer = 2;

        public void OnEnter(IContext context)
        {
            var playerbehaviour = ((PlayerContext) context).Behaviour;
            playerbehaviour.SetMovement(false);

            _subscriptionStop = new StateEventTransitionSubscription
            {
                Subscribeable = Resources.Load("Events/InteractionStop") as GameEvent
            };
        }


        public void OnExit(IContext context)
        {
            var playerbehaviour = ((PlayerContext) context).Behaviour;
            playerbehaviour.SetMovement(true);
            _subscriptionStop.UnSubscribe();
        }

        public void UpdateState(IContext context)
        {
            if (!_subscriptionStop.EventRaised) return;
 
            context.ChangeState(new PlayerIdleState());
        }
    }

    public class PlayerPauseState : IState
    {
        private StateEventTransitionSubscription _subscriptionClosePauseMenu;

        public void OnEnter(IContext context)
        {
            var playerbehaviour = ((PlayerContext) context).Behaviour;
            playerbehaviour.SetMovement(false);
            _subscriptionClosePauseMenu = new StateEventTransitionSubscription
            {
                Subscribeable = Resources.Load("Events/ClosePauseMenu") as GameEvent
            };
        }


        public void OnExit(IContext context)
        {
            var playerbehaviour = ((PlayerContext) context).Behaviour;
            playerbehaviour.SetMovement(true);
            _subscriptionClosePauseMenu.UnSubscribe();
        }

        public void UpdateState(IContext context)
        {
            if (_subscriptionClosePauseMenu.EventRaised)
                context.ChangeState(new PlayerIdleState());
        }
    }
}