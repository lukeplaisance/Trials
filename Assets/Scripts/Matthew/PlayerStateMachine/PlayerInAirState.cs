using Matthew;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zach;

public class PlayerInAirState : IState
{
    StateEventTransitionSubscription subscription_pause;

    public void OnEnter(IContext context)
    {
        subscription_pause = new StateEventTransitionSubscription
        {
            Subscribeable = UnityEngine.Resources.Load("Events/OpenPauseMenu") as Luke.GameEvent
        };
    }

    public void OnExit(IContext context)
    {
        subscription_pause.UnSubscribe();
    }

    public void UpdateState(IContext context)
    {
        var playercontext = (PlayerContext) context;
        if (NewPlayerMovementBehaviour.IsGrounded)
        {
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
