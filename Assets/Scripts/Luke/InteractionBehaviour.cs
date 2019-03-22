using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zach;

namespace Luke
{
    public class InteractionBehaviour : MonoBehaviour, IInteractable
    {
        [TagField]
        public string TriggerTag;
        [TextArea]
        public string readme;

        //public List<UnityEvent> thing;
        public UnityEvent _response;
        public UnityEvent InteractStopResponse;

        [SerializeField]
        public UnityEvent OnTriggerEnterResponse;
        [SerializeField]
        public UnityEvent OnTriggerExitResponse;

        private IInteractor _Interactor;

        public IInteractor Interactor
        {
            get { return _Interactor; }
            set { _Interactor = value; }
        }

        public UnityEvent Response
        {
            get { return _response; }
            set { _response = value; }
        }

        public void Interact(Object obj)
        {
            if (Interactor == null) return;
            if (obj != Interactor) return;
            Response.Invoke();
        }

        public void StopInteraction()
        {
            InteractStopResponse.Invoke();
        }
        /// <summary>
        /// comment this
        /// </summary>
        /// <param name="other"></param>
        public void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(TriggerTag)) return;
            Interactor = other.GetComponent<IInteractor>();
            if (Interactor == null) return;
            Interactor.SetInteraction(this);
            OnTriggerEnterResponse.Invoke();
        }

        public void OnTriggerExit(Collider other)
        {
            //release the interaction and disable the button
            //this was how it started...
            if (!other.CompareTag(TriggerTag)) return;

            Interactor.ReleaseInteraction(this);
            OnTriggerExitResponse.Invoke();
        }
    }
}
