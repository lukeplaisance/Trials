using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Persistence;

namespace Zach
{
    public class NoteScriptable : ScriptableObject
    {
        [SerializeField]
        private bool isEnabled;
        public string noteName;
        public string data;

        public static NoteScriptable Create(string name)
        {
            var note = CreateInstance<NoteScriptable>();
            var path = string.Format("Assets/Resources/{0}.asset", name);
            return note;
        }

        public bool GetIsEnabled()
        {
            return isEnabled;
        }
        public void SetIsEnabled(bool enabled)
        {
            isEnabled = enabled;
        }

        public void SetText(Text textui)
        {
            textui.text = data;
        }
    }

    

}