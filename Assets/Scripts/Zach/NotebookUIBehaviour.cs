using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Zach
{
    public class NotebookUIBehaviour : MonoBehaviour
    {
        public GameObject notePopUp;
        public NotebookScriptable nb;
        public float BaseOffsetY;
        private float baseYCopy;
        public float OffsetDistanceY;
        public float YPosLimit;

        public GameObject noteUI;

        // Use this for initialization
        void Start()
        {
            baseYCopy = BaseOffsetY;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void CreateButtons()
        {
            var journalUI = this.transform.GetChild(0);
            float XOffset = 0;
            foreach (var note in nb.notes)
            {
                if (-BaseOffsetY < YPosLimit)
                {
                    XOffset += 175;
                    BaseOffsetY = baseYCopy;
                }

                var noteUIObject = Instantiate(noteUI, journalUI);
                var uiButton = noteUIObject.GetComponent<Button>();
                var nUIB = noteUIObject.GetComponent<NoteUIBehaviour>();
                nUIB.note = note;
                nUIB.NotePopUp.Value = notePopUp;
                noteUIObject.transform.position += new Vector3(XOffset, -BaseOffsetY, 0);
                BaseOffsetY += OffsetDistanceY;
                Cursor.visible = true;
            }
        }

        public void DestroyNoteUI()
        {
            BaseOffsetY = baseYCopy;
            var notes = FindObjectsOfType<NoteUIBehaviour>();
            foreach (var note in notes)
            {
                Destroy(note.gameObject);
            }

            Cursor.visible = false;
        }
    }
}