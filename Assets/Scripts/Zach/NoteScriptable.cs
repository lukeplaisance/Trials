using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewNoteObject",menuName = "Zach/Note")]
public class NoteScriptable : ScriptableObject
{
    public bool IsEnabled;
    public string Name;
    public string Data;
}
