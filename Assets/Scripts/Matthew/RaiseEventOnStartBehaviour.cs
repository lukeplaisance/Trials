using Luke;
using UnityEngine;

public class RaiseEventOnStartBehaviour : MonoBehaviour
{
    public GameEvent StartEvent;

    private void Start()
    {
        StartEvent.Raise();
    }
}