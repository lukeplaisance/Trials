using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Luke
{
    public class PlayerMovementBehaviour : MonoBehaviour
    {
        public float speed = 5;
        public float jumpSpeed = 4;
        public float gravity = 9.81f;
        private CharacterController controller;
        private Vector3 moveDirection = Vector3.zero;

        private void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        void Update()
        {
            if(controller.isGrounded)
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    moveDirection.y = jumpSpeed;
                }

            }
           
            moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

            controller.Move(moveDirection * Time.deltaTime * speed);
        }

        public void Move(Vector3 direction)
        {
           
            if (direction != Vector3.zero)
            {
                transform.position += direction * Time.deltaTime * speed;
            }
        }
    }
}
