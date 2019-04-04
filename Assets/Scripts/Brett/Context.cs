using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Brett
{
    [System.Serializable]
    public abstract class Context : ScriptableObject
    {
        public abstract State CurrentState { get; set; }

        public abstract void ChangeState(State s);

        public abstract void Update();
 
    }
}
