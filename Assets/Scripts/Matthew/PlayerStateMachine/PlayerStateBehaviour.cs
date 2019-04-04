

using UnityEngine;
namespace Matthew
{


    public class PlayerStateBehaviour : MonoBehaviour
    {

        public Cinemachine.CinemachineFreeLook freeLookCamera;
        public Zach.NewPlayerMovementBehaviour movementBehaviour;
        public Luke.GameEvent PlayerStartEvent;
        public IContext PlayerContext;

        public void Start()
        {
            PlayerContext = new PlayerContext
            {
                CurrentState = new PlayerIdleState(),
                Behaviour = this
            };
            PlayerStartEvent.Raise();
        }
        public void SetMovement(bool state)
        {
            freeLookCamera.enabled = state;
            movementBehaviour.enabled = state;
        }
        private void Update()
        {
            PlayerContext.UpdateContext();
        }

    }
}