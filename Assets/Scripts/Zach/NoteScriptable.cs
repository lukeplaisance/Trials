using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR.WSA.Persistence;

namespace Zach
{
    //Try try again
    public class NoteScriptable : ScriptableObject
    {
        public bool isEnabled;
        public string noteName;
        public string data;

        public static NoteScriptable Create(string name)
        {
            NoteScriptable note = CreateInstance<NoteScriptable>();
            string path = string.Format("Assets/Resources/{0}.asset", name);
            return note;
        }
    }

    public class NotebookScriptable : ScriptableObject
    {
        [SerializeField]
        private List<NoteScriptable> notes;
        private List<NoteScriptable> Notes
        {
            get { return notes ?? (notes = new List<NoteScriptable>()); }
        }

        public static NotebookScriptable Create(string name)
        {
            var nbs = CreateInstance<NotebookScriptable>();
            var path = string.Format("Assets/Resources/{0}.asset", name);
            AssetDatabase.CreateAsset(nbs, path);
            return nbs;
        }

        public void AddNote(NoteScriptable note)
        {
            Notes.Add(note);
            AssetDatabase.AddObjectToAsset(note, this);
            AssetDatabase.SaveAssets();
        }
    }

    public static class CreateNotebookClass
    {
        [MenuItem("Tools/CreateNotebook")]
        public static void CreateNotebook()
        {
            var notebook = NotebookScriptable.Create("NewNotebook");
            var noteA = NoteScriptable.Create("NoteA");
            var noteB = NoteScriptable.Create("NoteB");
            notebook.AddNote(noteA);
            notebook.AddNote(noteB);
        }

        [MenuItem("Tools/AddNote")]
        public static void AddNoteToBook()
        {
            var path = string.Format("Assets/Resources/NewNotebook.asset");
            var notebook = AssetDatabase.LoadAssetAtPath<NotebookScriptable>(path);
            var noteC = NoteScriptable.Create("NoteC");
            notebook.AddNote(noteC);
        }
    }

}