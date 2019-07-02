using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class IncreasIntensity : MonoBehaviour
{
    public Light point_light;

	
	// Update is called once per frame
	void Update ()
    {
        point_light.intensity += 0.1f;
        if (point_light.intensity >= 50)
        {
            point_light.intensity = 50;
        }
    }
}
