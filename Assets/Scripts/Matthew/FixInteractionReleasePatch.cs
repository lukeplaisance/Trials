using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Luke;
using UnityEngine;

public class FixInteractionReleasePatch : MonoBehaviour
{
    public List<InteractionBehaviour> InteractableBehaviours;
	// Use this for initialization
	void Start ()
    {
        InteractableBehaviours = GetComponentsInChildren<InteractionBehaviour>().ToList();
        InteractableBehaviours.ForEach(ib => ib.InteractStopResponse.AddListener(ib.ReleaseInteraction));
    }
	
 
}
