using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Luke;

namespace Zach
{
    public class InteractorBehaviour : MonoBehaviour, IInteractor
    {
        public IInteractable currentInteraction;
        public void ReleaseInteraction(IInteractable interactable)
        {
            if (currentInteraction == interactable)
                currentInteraction = null;
            else
                Debug.LogWarning("Something tried to release an interaction that it wasn't involved in.");
        }

        public void SetInteraction(IInteractable interactable)
        {
            if (currentInteraction == null)
                currentInteraction = interactable;
            else
                Debug.LogWarning("Interactor already in an interaction.");
        }
    }
}