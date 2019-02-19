using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewNoteObject",menuName = "Zach/Note")]
//Try try again
public class NoteScriptable : ScriptableObject
{
    public bool IsEnabled;
    public string Name;
    public string Data;
}
