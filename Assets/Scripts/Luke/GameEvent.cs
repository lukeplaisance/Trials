using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif  
using UnityEngine;

namespace Luke
{
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject
    {
        private List<GameEventListener> listeners = new List<GameEventListener>();

        public void Subscribe(GameEventListener listener)
        {
            listeners.Add(listener);
        }

        public void UnSubscribe(GameEventListener listener)
        {
            listeners.Remove(listener);
        }

        public void Raise()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised();
                Debug.Log(name + " Event Raised");
            }
        }
    }

#if UNITY_EDITOR

    [CustomEditor(typeof(GameEvent))]
    public class GameEventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("RaiseEvent"))
            {
                var mt = target as GameEvent;
                mt.Raise();
            }
        }
    }
#endif
}
