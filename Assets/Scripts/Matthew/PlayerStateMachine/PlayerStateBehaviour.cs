

using System.Security.Permissions;
using Cinemachine;
using Luke;
using UnityEngine;
using Zach;

namespace Matthew
{


    public class PlayerStateBehaviour : StateBehaviour, IInteractor
    {
        public Zach.NewPlayerMovementBehaviour movementBehaviour;
        public Luke.GameEvent PlayerStartEvent;
        public GameObjectVariable flCam;
        private IContext PlayerContext;
        public GameEvent OpenMenu;
        public GameEvent CloseMenu;
        public GameEvent OpenWaypointMenu;
        public GameEvent CloseWaypointMenu;
        public bool PauseMenuOpen { get; set; }
        public bool WaypointMenuOpen { get; set; }

        public IInteractable CurrentInteraction;
        public void ReleaseInteraction(IInteractable interactable)
        {
            if (CurrentInteraction == interactable)
                CurrentInteraction = null;
            else
                Debug.LogWarning("Something tried to release an interaction that it wasn't involved in.");
        }

        public void SetInteraction(IInteractable interactable)
        {
            if (CurrentInteraction == null)
                CurrentInteraction = interactable;
            else
                Debug.LogWarning("Interactor already in an interaction.");
        }

   
        public override IContext Context
        {
            get { return PlayerContext; }
        }

        public void Start()
        {
            flCam = Resources.Load<GameObjectVariable>("References/ReferencePlayerFreeLookCameraReference");
            PlayerContext = new PlayerContext
            {
                Behaviour = this,
                CurrentState = new PlayerIdleState()
            };
            PlayerStartEvent.Raise();
        }
        public void SetMovement(bool state)
        {
            movementBehaviour.isFrozen = !state;
        }

        public void SetCamera(bool state)
        {
            var cam = flCam.Value.GetComponent<CinemachineFreeLook>();
            if (state)
            {
                cam.m_XAxis.m_MaxSpeed = 300;
                cam.m_YAxis.m_MaxSpeed = 2;
            }
            else
            {
                cam.m_XAxis.m_MaxSpeed = 0;
                cam.m_YAxis.m_MaxSpeed = 0;
            }
        }
        private void Update()
        {
            PlayerContext.UpdateContext();

            // Update is called once per frame

            if (Input.GetButton("Home"))
            {
                if (Input.GetButtonDown("LB"))
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

}