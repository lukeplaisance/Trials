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
        private Vector2 m_scrollPos2;
        private string Title;
        private string Content;
        private List<NotebookScriptable> notebooks;
        private NotebookScriptable notebook;
        private NoteScriptable noteC;

        [MenuItem("Tools/NoteMakerEditor")]

        private static void Init()
        {
            var w = GetWindow(typeof(NoteMakerEditor));
            w.Show();
        }

        private void OnEnable()
        {
            var assets = AssetDatabase.FindAssets("t:NotebookScriptable").
                Select(guid => AssetDatabase.GUIDToAssetPath(guid)).
                Select(path => AssetDatabase.LoadAssetAtPath<NotebookScriptable>(path)).
                Where(notebook => notebook).ToList();
            notebooks = new List<NotebookScriptable>(assets);
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
            EditorGUILayout.BeginHorizontal();
            m_scrollPos = EditorGUILayout.BeginScrollView(m_scrollPos, GUILayout.Height(200));
            Content = EditorGUILayout.TextArea(Content, GUILayout.Height(200), GUILayout.Width(250));

            EditorGUILayout.EndScrollView();

            m_scrollPos2 = EditorGUILayout.BeginScrollView(m_scrollPos2, GUILayout.Height(200));
            foreach (var notebook in notebooks)
            {
                var notebook_obj = EditorGUILayout.ObjectField(notebook, typeof(NotebookScriptable), false) as NotebookScriptable;
                EditorGUI.indentLevel++;
                notebook_obj.notes.ForEach(note=>EditorGUILayout.ObjectField(note, typeof(NoteScriptable),false));
                EditorGUI.indentLevel--;
            }

            EditorGUILayout.EndScrollView();

            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button("Create Note"))
            {
                noteC = NoteScriptable.Create("NoteC");
                notebook = AssetDatabase.LoadAssetAtPath<NotebookScriptable>(AssetDatabase.GetAssetPath(notebooks[0]));
                noteC.name = Title;
                noteC.noteName = Title;
                noteC.data = Content;
                notebook.AddNote(noteC);
            }
            GUILayout.EndVertical();
        }
    }
}
