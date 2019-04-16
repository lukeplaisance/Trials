

using UnityEngine;
namespace Matthew
{


    public class PlayerStateBehaviour : MonoBehaviour
    {

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
            movementBehaviour.isFrozen = !state;
        }
        private void Update()
        {
            PlayerContext.UpdateContext();
        }

    }
}