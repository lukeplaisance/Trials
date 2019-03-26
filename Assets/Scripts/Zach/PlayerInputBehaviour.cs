using System.Collections;
using System.Collections.Generic;
using Luke;
using UnityEngine;
using UnityEngine.Events;

namespace Zach
{
    public class PlayerInputBehaviour : InteractorBehaviour
    {
        public string InteractionState;
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && currentInteraction != null)
            {
                currentInteraction.Interact(this);
                InteractionState = currentInteraction == null ? "available":"interacting";
            }
        }
    }
}
