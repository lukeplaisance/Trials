using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    private float v;
    private float h;
	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
	}

    private void FixedUpdate()
    {
        animator.SetFloat("Run", v);
    }
}
