using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zach
{
    public interface IInteractor
    {
        void SetInteraction(IInteractable interactable);

        void ReleaseInteraction(IInteractable interactable);
    }
}