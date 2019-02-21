using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using Zach;

namespace Luke
{
    public class NoteMakerEditor : EditorWindow
    {
        Vector2 m_scrollPos;
        private string Title;
        private string Content;

        [MenuItem("Tools/NoteMakerEditor")]

        private static void Init()
        {
            var w = GetWindow(typeof(NoteMakerEditor));
            w.Show();
        }

        private void OnInspectorUpdate()
        {
            Repaint();
        }

        private void OnGUI()
        {
            GUILayout.BeginVertical();

            EditorGUILayout.LabelField("Title");
            Title = EditorGUILayout.TextArea(Title, GUILayout.Height(20), GUILayout.Width(250));
            EditorGUILayout.Space();
            
            EditorGUILayout.LabelField("Content");
            m_scrollPos = EditorGUILayout.BeginScrollView(m_scrollPos, GUILayout.Height(200));
            Content = EditorGUILayout.TextArea(Content, GUILayout.Height(200), GUILayout.Width(450));
            EditorGUILayout.EndScrollView();

            if (GUILayout.Button("Create Note"))
            {
                var note = CreateInstance(typeof(NoteScriptable)) as NoteScriptable;
                note.noteName = Title;
                note.data = Content;

                AssetDatabase.CreateAsset(note, string.Format("Assets/Resources/Notes/{0}.asset", Title));
            }
            GUILayout.EndVertical();
        }
    }
}
