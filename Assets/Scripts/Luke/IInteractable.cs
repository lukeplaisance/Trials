using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Zach;

namespace Luke
{
    public interface IInteractable
    {
        void Interact(Object obj);
        IInteractor Interactor { get; set; }
        UnityEvent Response { get; set; }
    }
}
