using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RespondOnStartBehaviour : MonoBehaviour
{
    public UnityEvent OnStartResponse;
    public UnityEvent OnEnableResponse;
    public UnityEvent OnDisableResponse;
    
    // Use this for initialization
    void Start ()
    {
        OnStartResponse.Invoke();

    }
	
	// Update is called once per frame
    void OnDisable()
    {
        OnDisableResponse.Invoke();
    }

    void OnEnable()
    {
        OnEnableResponse.Invoke();
    }
}
