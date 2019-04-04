using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Assets.Scripts.Brett
{
    [CreateAssetMenu(menuName = "GameStateScriptable")]
    public class GameStateScriptable : ScriptableObject, ISerializationCallbackReceiver
    {
        public State StateField;
        public string StateTypeName;
        public void OnBeforeSerialize()
        {
            if (StateField == null)
                StateField = new NullState();
            StateTypeName = StateField.GetType().ToString();
        }

        public void OnAfterDeserialize()
        {
            var field = GetType().GetField("StateField");
            var t = Type.GetType(StateTypeName);
            if (t != null)
            {
                field.SetValue(this, Activator.CreateInstance(t));
            }

            StateTypeName = StateField.GetType().ToString();
        }
    }
}