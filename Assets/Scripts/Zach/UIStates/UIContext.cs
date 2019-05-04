using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zach
{
    public class UIContext : IContext
    {
        public UIStateBehaviour Behaviour { get; set; }
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

        public void ChangeState(IState next)
        {
            Debug.Log(string.Format("{0} -> {1}", CurrentState, next));
            _currentState.OnExit(this);
            _currentState = next;
            _currentState.OnEnter(this);

        }

        public void ResetContext()
        {
            _currentState = new UIHiddenState();
            _currentState.OnEnter(this);
        }

        public void UpdateContext()
        {
            _currentState.UpdateState(this);    
        }
    }
}