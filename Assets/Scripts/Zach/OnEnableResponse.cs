using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableResponse : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent OnEnableResponses;
    private void OnEnable()
    {
        OnEnableResponses.Invoke();
    }
}
