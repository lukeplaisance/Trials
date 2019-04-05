using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            CurrentState.UpdateState(this);
        }

        public void ResetContext()
        {
            CurrentState = new PlayerIdleState();
            CurrentState.OnEnter(this);
        }


        public void ChangeState(IState next)
        {
            Debug.Log(string.Format("{0} -> {1}", CurrentState, next));
            CurrentState.OnExit(this);
            CurrentState = next;
            CurrentState.OnEnter(this);
        }
    }
}