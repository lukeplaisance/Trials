

using Cinemachine;
using UnityEngine;
namespace Matthew
{


    public class PlayerStateBehaviour : MonoBehaviour
    {

        public Zach.NewPlayerMovementBehaviour movementBehaviour;
        public Luke.GameEvent PlayerStartEvent;
        public GameObjectVariable flCam;
        private IContext PlayerContext;

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

            movementBehaviour.isFrozen = !state;
        }
        private void Update()
        {
            PlayerContext.UpdateContext();
        }

    }
}