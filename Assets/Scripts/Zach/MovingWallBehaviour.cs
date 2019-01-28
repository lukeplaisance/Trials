using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWallBehaviour : MonoBehaviour
{
    public Vector3 Direction;
    public float Speed;
    public bool IsMoving = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(IsMoving)
            transform.position += Direction * Speed * Time.deltaTime;
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if(hit.collider.gameObject.tag == "Terrain")
            {
            }
        }
	}
}
