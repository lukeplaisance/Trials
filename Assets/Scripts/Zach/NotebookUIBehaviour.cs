using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zach;

public class NotebookUIBehaviour : MonoBehaviour
{
    public GameObject notePopUp;
    public NotebookScriptable nb;

    public GameObject noteUI;
	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void CreateButtons()
    {
        var journalUI = this.transform.GetChild(0);
        float yOffset = 30;
        foreach (var note in nb.notes)
        {
            var noteUIObject = Instantiate(noteUI,journalUI);
            var uiButton = noteUIObject.GetComponent<Button>();
            var nUIB = noteUIObject.GetComponent<NoteUIBehaviour>();
            nUIB.note = note;
            nUIB.NotePopUp = notePopUp;
            noteUIObject.transform.position -= new Vector3(0, yOffset, 0);
            yOffset += 30;
        }
    }

    public void DestroyNoteUI()
    {
        var notes = FindObjectsOfType<NoteUIBehaviour>();
        foreach (var note in notes)
        {
            Destroy(note.gameObject);
        }
    }
}
