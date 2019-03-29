using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zach;

public class NoteUIBehaviour : MonoBehaviour
{
    public NoteScriptable note;
    private Button bttn;
    public void Start()
    {
        bttn = GetComponent<Button>();
    }

    public void Update()
    {
        bttn.interactable = note.GetIsEnabled();
    }
    public void SetText(Text textUI)
    {
        textUI.text = note.data;
    }
}
