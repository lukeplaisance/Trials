using System;
using System.Linq;
using Assets.Scripts.Brett;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
   
    public class StateDrawer : PropertyDrawer
    {
        private string stateName = "select state";
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.LabelField(position: position, label: "DOIT", label2: "DOITAGAIN");
        }

        public void Populate(SerializedProperty property, Rect position, GUIContent label)
        {
            var assembly = property.GetType().Assembly;
            var baseType = typeof(State);
            var stateTypes = assembly.GetTypes().Where(stateType => baseType.IsAssignableFrom(typeof(State))).ToList();
            EditorGUI.LabelField(position, label);
            position.x += EditorGUIUtility.labelWidth;
            if (EditorGUI.DropdownButton(position, new GUIContent { text = stateName }, FocusType.Passive))
            {
                var gm = new GenericMenu();
                stateTypes.ForEach(
                    s => gm.AddItem(new GUIContent { text = s.Name }, false,
                        () =>
                        {
                            var newstate = Activator.CreateInstance(s) as State;
                            stateName = s.Name;

                        }));
                gm.ShowAsContext();
            }
        }
    }
}