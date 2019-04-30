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
        public GameEvent OpenWaypointMenu;
        public GameEvent CloseWaypointMenu;
        public bool PauseMenuOpen { get; set; }
        public bool WaypointMenuOpen { get; set; }
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
                
                if (PauseMenuOpen)
                {
                    
                    CloseMenu.Raise();
                }
                    
                else
                {
                    
                    OpenMenu.Raise();
                }
                PauseMenuOpen = !PauseMenuOpen;

            }

            if (Input.GetButtonDown("Home"))
            {
                if (WaypointMenuOpen)
                {
                    CloseWaypointMenu.Raise();
                }
                else
                {
                    OpenWaypointMenu.Raise();
                }

                WaypointMenuOpen = !WaypointMenuOpen;
            }
        }
    }
}
