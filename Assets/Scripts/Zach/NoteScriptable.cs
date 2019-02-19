using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Trials/Note")]
//Try try again
public class NoteScriptable : ScriptableObject
{
    public bool isEnabled;
    public string name;
    public string data;
}
