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
        public GameEvent CloseMenu;
        private bool MenuOpen = false;
        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Interact") && currentInteraction != null)
            {
                if (InteractionState == "available" || InteractionState == "")
                {
                    currentInteraction.Interact(this);
                    InteractionState = currentInteraction == null ? "available" : "interacting";
                }

                if (InteractionState == "interacting")
                {
                    currentInteraction.StopInteraction();
                    InteractionState = "available";
                }
            }
            else if (Input.GetButtonDown("Pause"))
            {
                if(MenuOpen)
                    CloseMenu.Raise();
                else
                    OpenMenu.Raise();
                MenuOpen = !MenuOpen;
            }
        }
    }
}
