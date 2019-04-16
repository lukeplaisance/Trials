

using UnityEngine;
namespace Matthew
{


    public class PlayerStateBehaviour : MonoBehaviour
    {

        public Cinemachine.CinemachineFreeLook freeLookCamera;
        public Zach.NewPlayerMovementBehaviour movementBehaviour;
        public Luke.GameEvent PlayerStartEvent;
        private IContext PlayerContext;

        public void Start()
        {
            PlayerContext = new PlayerContext
            {
                Behaviour = this,
                CurrentState = new PlayerIdleState()
            };
            PlayerStartEvent.Raise();
        }
        public void SetMovement(bool state)
        {
            freeLookCamera.enabled = state;
            movementBehaviour.isFrozen = !state;
        }
        private void Update()
        {
            PlayerContext.UpdateContext();
        }

    }
}