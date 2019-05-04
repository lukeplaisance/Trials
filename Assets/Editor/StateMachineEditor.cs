using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Matthew
{
    public class StateMachineEditor : EditorWindow
    {
        [MenuItem("Tools/StateMachineEditor")]
        private static void Init()
        {
            var w = GetWindow(typeof(StateMachineEditor));
            w.Show();
        }

        public static List<StateBehaviour> StateBehaviours;

        private void OnEnable()
        {
            RefreshStateBehaviourList();
        }
        

        public void RefreshStateBehaviourList()
        {
            StateBehaviours = new List<StateBehaviour>();
            var sbs = FindObjectsOfType<StateBehaviour>();
            StateBehaviours.AddRange(sbs);
        }
        private void Update()
        {
            Repaint();
        }
        private void OnGUI()
        {
            EditorGUILayout.Space();
            
            RefreshStateBehaviourList();
            foreach (var sb in StateBehaviours)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(sb?.name);
                GUILayout.TextField(sb.Context?.CurrentState?.ToString());
                GUILayout.EndHorizontal();

            }
        }

    }
}