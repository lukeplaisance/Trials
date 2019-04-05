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
        public GameEvent InteractionEnter;
        public GameEvent InteractionExit;
        public GameEvent InteractionStart;
        public GameEvent InteractionStop;
        //public List<UnityEvent> thing;
        public UnityEvent OnInteractionResponse;
        public UnityEvent InteractStopResponse;

        [SerializeField]
        public UnityEvent OnTriggerEnterResponse;
        [SerializeField]
        public UnityEvent OnTriggerExitResponse;

        private IInteractor _Interactor;

        private void Start()
        {
            InteractionEnter = Resources.Load<GameEvent>("Events/InteractionEnter");
            InteractionExit = Resources.Load<GameEvent>("Events/InteractionExit");
            InteractionStart = Resources.Load<GameEvent>("Events/InteractionStart");
            InteractionStop = Resources.Load<GameEvent>("Events/InteractionStop");
        }

        public IInteractor Interactor
        {
            get { return _Interactor; }
            set { _Interactor = value; }
        }

        public UnityEvent Response
        {
            get { return OnInteractionResponse; }
            set { OnInteractionResponse = value; }
        }

        public void Interact(Object obj)
        {
            if (Interactor == null) return;
            if (obj != Interactor) return;
            InteractionStart.Raise();
            Response.Invoke();
        }

        public void StopInteraction()
        {
            InteractionStop.Raise();
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
            InteractionEnter.Raise();
            OnTriggerEnterResponse.Invoke();
        }

        public void OnTriggerExit(Collider other)
        {
            //release the interaction and disable the button
            //this was how it started...
            if (!other.CompareTag(TriggerTag)) return;

            Interactor.ReleaseInteraction(this);
            InteractionExit.Raise();
            OnTriggerExitResponse.Invoke();
            
        }
    }
}
