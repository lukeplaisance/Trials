using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zach;

public class NoteUIBehaviour : MonoBehaviour
{
    public GameObject NotePopUp;
    public NoteScriptable note;
    private Button bttn;
    public void Start()
    {
        bttn = GetComponent<Button>();
        var textObject = this.transform.GetChild(0);
        var textComp = textObject.GetComponent<Text>();
        textComp.text = note.noteName;
    }

    public void Update()
    {
        bttn.interactable = note.GetIsEnabled();
    }
    public void SetText(Text textUI)
    {
        textUI.text = note.data;
    }

    public void OnClick()
    {
        
        NotePopUp.SetActive(true);
        var popUpChild = NotePopUp.transform.GetChild(0);
        var popUpText = popUpChild.GetComponent<Text>();
        popUpText.text = note.data;

    }
}
