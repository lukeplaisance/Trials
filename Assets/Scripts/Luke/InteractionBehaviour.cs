using Cinemachine;
using UnityEngine;
using UnityEngine.Events;
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
        public GameEvent InteractionStay;
        public GameEvent InteractionExit;
        public GameEvent InteractionStart;
        public GameEvent InteractionStop;
        //public List<UnityEvent> thing;
        public UnityEvent OnInteractionResponse;
        public UnityEvent InteractStopResponse;

        [SerializeField]
        public UnityEvent OnTriggerStayResponse;
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
            InteractionStay = Resources.Load<GameEvent>("Events/InteractionStay");
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
            
            Response.Invoke();//if you stop interaction here then the player will get stuck due to the following
            //responses for stop get called
            //interaction stop gets raised
            //player does nothing because he is in idle
            //interaction start gets raised
            //player enters the interacting state
            InteractionStart.Raise();
        }

        public void StopInteraction()
        {
            Debug.Log("stopping interaction");
            InteractStopResponse.Invoke();
            InteractionStop.Raise();
        }

        public void ReleaseInteraction()
        {
            Interactor.ReleaseInteraction(this);
            InteractionExit.Raise();
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
        public void SetInteractionToThis()
        {   
            Interactor.SetInteraction(this);
        }

        private void OnTriggerStay(Collider other)
        {
            if (!other.CompareTag(TriggerTag)) return;
            Interactor = other.GetComponent<IInteractor>();
            if (Interactor == null) return;
            InteractionStay.Raise();
            OnTriggerStayResponse.Invoke();
        }

        public void OnTriggerExit(Collider other)
        {
            //release the interaction and disable the button
            //this was how it started...
            if (!other.CompareTag(TriggerTag)) return;

            ReleaseInteraction();
            OnTriggerExitResponse.Invoke();            
        }
    }
}
