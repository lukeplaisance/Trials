using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AstrolabeBehaviour : MonoBehaviour
{
    public UnityEvent Activate;
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire4"))
        {
            Activate.Invoke();
        }
	}
}
