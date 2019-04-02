using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Luke;

namespace Zach
{
    public interface IInteractor
    {
        void SetInteraction(IInteractable interactable);

        void ReleaseInteraction(IInteractable interactable);
    }
}