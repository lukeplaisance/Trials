using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovementBehaviour : MonoBehaviour
{
    private Vector3 moveVector;
    public float speed = 5;
    public float jumpPower = 4;
    public float gravity = 9.81f;
    private CharacterController controller;
    public Vector3 camRight;
    public Vector3 camForward;
    public bool IsFrozen = false;

    void Start ()
    {
        controller = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (!IsFrozen)
        {
            if (controller.isGrounded)
            {
                camRight = Camera.main.transform.right;
                camForward = Camera.main.transform.forward;
                camForward *= PlayerInput.InputVector.z;
                camRight *= PlayerInput.InputVector.x;

                moveVector = (camForward + camRight);
                var right = new Vector3(camForward.z, 0, -camForward.x);
                //if (Input.GetKeyDown(KeyCode.Space))
                //{
                //    controller.Move(new Vector3(0, jumpPower, 0));
                //}
            }
            //transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * 180 * Time.deltaTime);
            //moveVector.y = moveVector.y - (gravity * Time.deltaTime);
            transform.forward = new Vector3(Camera.main.transform.forward.x, transform.forward.y, Camera.main.transform.forward.z);
            controller.SimpleMove(moveVector * speed);
        }
    }
}
