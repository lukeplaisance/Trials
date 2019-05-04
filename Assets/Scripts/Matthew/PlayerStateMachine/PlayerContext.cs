using System.Collections;
using System.Collections.Generic;
using Luke;
using UnityEngine;
using Zach;

namespace Matthew
{
    public class PlayerContext : IContext
    {

        //we store references here to handle the disabling of monobehaviours specific to 
        //the states. EX: Interacting state will disable the playercontroller
        public PlayerStateBehaviour Behaviour { get; set; }
        private IState _currentState;
        public IState CurrentState
        {
            get { return _currentState; }
            set
            {
                _currentState = value;
                _currentState.OnEnter(this);
            }
        }

        public void UpdateContext()
        {
            _currentState.UpdateState(this);
        }

        public void ResetContext()
        {
            _currentState = new PlayerIdleState();
            _currentState.OnEnter(this);
        }


        public void ChangeState(IState next)
        {
            _currentState.OnExit(this);
            _currentState = next;
            _currentState.OnEnter(this);
        }
    }
}