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
            currentInteraction = null;
        }

        public void SetInteraction(IInteractable interactable)
        {
            currentInteraction = interactable;
        }
    }
}