using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Brett
{
    [CustomEditor(typeof(GameStateScriptable),true)]
    public class GameStateScriptableInspector : UnityEditor.Editor
    {
        
        public FieldInfo StateFieldInfo;

        public State selectedState;

        public List<Type> stateTypes;

        private SerializedProperty stateFieldProperty => serializedObject.FindProperty("StateField");
        private SerializedProperty stateTypeNameProperty => serializedObject.FindProperty("StateTypeName");
        private void OnEnable()
        {
            StateFieldInfo = target.GetType().GetField("StateField");
            var assembly = target.GetType().Assembly;
            var baseType = typeof(State);
            stateTypes = assembly.GetTypes().Where(stateType => baseType.IsAssignableFrom(stateType)).ToList(); 
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            selectedState = StateFieldInfo.GetValue(target) as State;
            EditorGUILayout.PropertyField(stateTypeNameProperty);
            DrawStateField();

            serializedObject.ApplyModifiedProperties();
        }

        private void DrawStateField()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("State");
            var rect = GUILayoutUtility.GetLastRect();
            rect.x += EditorGUIUtility.labelWidth;
            if (EditorGUI.DropdownButton(rect, new GUIContent { text = stateTypeNameProperty?.stringValue }, FocusType.Passive))
            {
                var gm = new GenericMenu();
                stateTypes.ForEach(
                    s => gm.AddItem(new GUIContent { text = s.Name }, false, Func, new object[] { serializedObject, s }));

                gm.ShowAsContext();
            }
            EditorGUILayout.EndHorizontal();
        }

        private void Func(object userdata)
        {
            var args = userdata as object[];
            if (args == null) return;
            var so = args[0] as SerializedObject;
            var t = args[1] as Type;
            if (so == null || t == null) return;
            var newstate = Activator.CreateInstance(t);
            StateFieldInfo.SetValue(target, newstate);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}