using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAD : MonoBehaviour
{
    public MovingWallBehaviour wall1;
    public MovingWallBehaviour wall2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            wall1.IsMoving = true;
            wall2.IsMoving = true;
        }
    }
}
