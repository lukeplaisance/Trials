using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Some of Mr. Matthews stuff isn't namespaced, if he namespaces it later and this breaks
//don't blame me. - Zach
namespace Zach
{
    public class UIStateBehaviour : Matthew.StateBehaviour
    {
        public IContext UIContext;

        public GameObject JournalUI;

        public GameObject NoteUI;

        public override IContext Context
        {
            get { return UIContext; }
        }

        // Use this for initialization
        void Start()
        {
            UIContext = new UIContext()
            {
                Behaviour = this,
                CurrentState = new UIHiddenState()
            };
        }

        // Update is called once per frame
        void Update()
        {
            UIContext.UpdateContext();

        }

        public void SetNoteActive(bool state)
        {
            NoteUI.SetActive(state);
           
        }

        public void SetJournalActive(bool state)
        {
            JournalUI.SetActive(state);

        }
    }
}
