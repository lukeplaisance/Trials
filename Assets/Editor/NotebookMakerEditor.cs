using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Luke;

namespace Zach
{
    public static class NotebookMakerEditor
    {
        [MenuItem("Tools/CreateNotebook")]
        public static void CreateNotebook()
        {
            var notebook = NotebookScriptable.Create("NewNotebook");
            var noteA = NoteScriptable.Create("NoteA");
            noteA.name = "InitNote";
            noteA.noteName = "InitNote";
            noteA.data = "Contents go here.";
            notebook.AddNote(noteA);
        }

        //[MenuItem("Tools/AddNoteToNotebook")]
        //public static void AddNoteToBook()
        //{
        //    var path = string.Format("Assets/Resources/NewNotebook.asset");
        //    var notebook = AssetDatabase.LoadAssetAtPath<NotebookScriptable>(path);
        //    var noteC = NoteScriptable.Create("NoteC");
        //    notebook.AddNote(noteC);
        //}
    }
}