using System;
using System.Collections;
using System.Collections.Generic;
using Luke;
using UnityEditor;
using UnityEditor.Experimental.Rendering;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;
using System.Reflection;

//[CustomEditor(typeof(InteractionBehaviour),true,isFallback = true)]
//[CanEditMultipleObjects]
//public class InteractionBehaviourEditor : Editor
//{

//    private InteractionBehaviour target;
//    private UnityEventBase ue;
//    public ReorderableList EventReorderableList;
//    public void OnEnable()
//    {
//        target = (InteractionBehaviour) target;
//        EventReorderableList = new ReorderableList(serializedObject, serializedObject.FindProperty("thing"), true, true, true, true);
//        EventReorderableList.drawHeaderCallback = rect =>
//        {
//            EditorGUI.LabelField(rect, "EventList", EditorStyles.boldLabel);
//        };
//        EventReorderableList.drawElementCallback = (Rect Rect, int index, bool isActive, bool isFocused) =>
//        {
//            var element = EventReorderableList.serializedProperty;
//            EditorGUI.ObjectField(new Rect(Rect.x, Rect.y, Rect.width, EditorGUIUtility.singleLineHeight), element,
//                GUIContent.none);
//        };
//    }

//    public override void OnInspectorGUI()
//    {
//        serializedObject.Update();
//        EventReorderableList.DoLayoutList();
//        serializedObject.ApplyModifiedProperties();
//    }
//}
