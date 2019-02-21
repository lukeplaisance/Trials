using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Zach
{
    [CreateAssetMenu(menuName = "Trials/Note")]
    //Try try again
    public class NoteScriptable : ScriptableObject
    {
        public bool isEnabled;
        public string noteName;
        public string data;
    }

}