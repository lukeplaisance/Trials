using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Zach
{
    public class NotebookScriptable : ScriptableObject
    {
        public List<NoteScriptable> notes;

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
}