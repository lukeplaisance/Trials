using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR.WSA.Persistence;

namespace Zach
{
    public class NoteScriptable : ScriptableObject
    {
        public bool isEnabled;
        public string noteName;
        public string data;

        public static NoteScriptable Create(string name)
        {
            var note = CreateInstance<NoteScriptable>();
            var path = string.Format("Assets/Resources/{0}.asset", name);
            return note;
        }
    }

    

}