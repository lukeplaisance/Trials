using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Zach
{
    public class NotebookUIBehaviour : MonoBehaviour
    {
        public GameObject notePopUp;
        public GameObject noteButtonParent;
        public GameObject CloseButton;
        public NotebookScriptable nb;
        public float BaseOffsetY;
        private float baseYCopy;
        public float OffsetDistanceY;
        public float YPosLimit;
        public EventSystem eventSys;
        public GameObject noteUI;
        public List<GameObject> buttonGOs = new List<GameObject>();

        public UnityEngine.Events.UnityEvent OnEnableResponses;
        public UnityEngine.Events.UnityEvent OnDisableResponses;

        public void OnEnable()
        {
            OnEnableResponses.Invoke();

        }

        public void OnDisable()
        {
            OnDisableResponses.Invoke();
        }

        // Use this for initialization
        void Start()
        {
            baseYCopy = BaseOffsetY;
        }

        // Update is called once per frame
        void Update()
        {

        }
        public List<GameObject> notes = new List<GameObject>();
        public void CreateButtons()
        {
            float XOffset = 0;
            foreach (var note in nb.notes)
            {
                if (-BaseOffsetY < YPosLimit)
                {
                    XOffset += 175;
                    BaseOffsetY = baseYCopy;
                }

                var noteUIObject = Instantiate(noteUI, noteButtonParent.transform);
                notes.Add(noteUIObject);
                var uiButton = noteUIObject.GetComponent<Button>();
                var nUIB = noteUIObject.GetComponent<NoteUIBehaviour>();
                nUIB.note = note;
                nUIB.NotePopUp.Value = notePopUp;
                noteUIObject.transform.position += new Vector3(XOffset, -BaseOffsetY, 0);
                BaseOffsetY += OffsetDistanceY;
                Cursor.visible = true;
                buttonGOs.Add(noteUIObject);
                
            }
        }

        public void DestroyNoteUI()
        {
            BaseOffsetY = baseYCopy;
            
            foreach (var note in notes)
            {
                Destroy(note);
     
            }
            notes = new List<GameObject>();
            Cursor.visible = false;
        }

        public void TurnOffUI()
        {
            noteButtonParent.SetActive(false);
            CloseButton.SetActive(false);
        }

        public void SetSelected()
        {
            var button = buttonGOs[0].GetComponent<Button>();
            eventSys.SetSelectedGameObject(button.gameObject);
            button.OnSelect(null);
        }
    }
}