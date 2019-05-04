namespace Matthew
{
    public class PlayerInteractState : IState
    {        
        public void OnEnter(IContext context)
        { 
            ((PlayerContext)context).Behaviour.SetMovement(false); 
        }


        public void OnExit(IContext context)
        { 
            ((PlayerContext)context).Behaviour.SetMovement(true);
        }

        public void UpdateState(IContext context)
        {
            if (Zach.PlayerInput.CancelPressed)
            {
                ((PlayerContext)context).Behaviour.CurrentInteraction.StopInteraction();
                context.ChangeState(new PlayerIdleState());
                return;
            }
            if (Zach.PlayerInput.PausePressed)
            {                
                context.ChangeState(new PlayerPauseState());
                return;
            }

        }
    }
}