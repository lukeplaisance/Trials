using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zach;

namespace Luke
{
    public class InteractionBehaviour : MonoBehaviour, IInteractable
    {
        public IInteractor Interactor { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public UnityEvent Response { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void Interact(Object obj)
        {
            if (Interactor == null) return;
            if (obj != Interactor) return;
            Response.Invoke();
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Interactor = other.GetComponent<IInteractor>();
                if (Interactor == null) return;

                Interactor.SetInteraction(this);
            }

        }

        public void OnTriggerExit(Collider other)
        {
            Interactor.ReleaseInteraction(this);
        }
    }
}
