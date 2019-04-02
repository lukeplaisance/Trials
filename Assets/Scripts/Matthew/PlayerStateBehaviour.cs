using UnityEngine;

public class PlayerStateBehaviour : MonoBehaviour
{
    public Cinemachine.CinemachineFreeLook freeLookCamera;
    public Zach.NewPlayerMovementBehaviour movementBehaviour;
    public Luke.GameEvent PlayerStartEvent;
    public void Start()
    {
        PlayerStartEvent.Raise();
    }
    public void SetMovement(bool state)
    {
        if(state)
        {
            freeLookCamera.enabled = true;
            movementBehaviour.enabled = true;
        }
        else
        {
            freeLookCamera.enabled = false;
            movementBehaviour.enabled = false;
            
        }        
    }
}
