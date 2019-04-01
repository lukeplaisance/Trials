using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zach;
using Matthew;

namespace Zach
{
    public class NoteUIBehaviour : MonoBehaviour
    {
        public GameObjectVariable NotePopUp;
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

            NotePopUp.Value.transform.GetChild(0).gameObject.SetActive(true);
            var PopUpTextChild = NotePopUp.Value.transform.GetChild(1);
            PopUpTextChild.gameObject.SetActive(true);
            NotePopUp.Value.transform.GetChild(2).gameObject.SetActive(true);
            var popUpText = PopUpTextChild.GetComponent<Text>();
            popUpText.text = note.data;

        }
    }
}