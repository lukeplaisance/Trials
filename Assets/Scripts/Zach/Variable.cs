using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zach
{
    public abstract class Variable : ScriptableObject
    {
        public abstract object Value { get; set; }
        public abstract object MaxValue { get; set; }

        public delegate void OnValueChanged(object obj);

        public OnValueChanged onValueChanged;
    }
}