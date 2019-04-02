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
        public bool MenuOpen { get; set; }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Submit") && currentInteraction != null)
            {
                currentInteraction.Interact(this);
                InteractionState = currentInteraction == null ? "available" : "interacting";
            }

            if (Input.GetButtonDown("Cancel") && currentInteraction != null)
            {
                currentInteraction.StopInteraction();
                InteractionState = currentInteraction == null ? "available" : "interacting";
            }

            if (Input.GetButtonDown("Pause"))
            {
                
                if (MenuOpen)
                {
                    
                    CloseMenu.Raise();
                }
                    
                else
                {
                    
                    OpenMenu.Raise();
                }
                MenuOpen = !MenuOpen;

            }
        }
    }
}
