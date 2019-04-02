using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Zach
{
    public class NewPlayerMovementBehaviour : MonoBehaviour
    {
        private Vector3 _moveVector;
        public float speed = 5;
        public float jumpPower = 4;
        public float gravity = 9.81f;
        private CharacterController _controller;
        public Vector3 camRight;
        public Vector3 camForward;
        public bool isFrozen = false;

        private void Start()
        {
            _controller = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }

            if (!isFrozen)
            {
                if (_controller.isGrounded)
                {
                    if (Camera.main != null)
                    {
                        var transform3 = Camera.main.transform;
                        camRight = transform3.right;
                        camForward = transform3.forward;
                    }

                    camForward *= PlayerInput.InputVector.z;
                    camRight *= PlayerInput.InputVector.x;

                    _moveVector = (camForward + camRight);
                    var right = new Vector3(camForward.z, 0, -camForward.x);
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        _moveVector += new Vector3(0,jumpPower,0);
                    }
                }

                transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * 180 * Time.deltaTime);
                _moveVector.y = _moveVector.y - (gravity * Time.deltaTime);
                var transform1 = transform;
                if (Camera.main != null)
                {
                    var transform2 = Camera.main.transform;
                    var forward = transform2.forward;
                    transform1.forward = new Vector3(forward.x, transform1.forward.y,
                        forward.z);
                }

                _controller.Move(_moveVector * speed * Time.deltaTime);
            }
        }
    }
}