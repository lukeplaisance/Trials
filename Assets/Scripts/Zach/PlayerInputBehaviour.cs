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

        public GameEvent OpenMenu;
        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Interact") && currentInteraction != null)
            {
                currentInteraction.Interact(this);
                InteractionState = currentInteraction == null ? "available":"interacting";
            }
            else if (Input.GetKeyDown(KeyCode.X) && currentInteraction != null)
            {
                currentInteraction.StopInteraction();
                InteractionState = currentInteraction == null ? "available" : "interacting";
            }
            else if (Input.GetButtonDown("Pause"))
            {
                OpenMenu.Raise();
            }
        }
    }
}
