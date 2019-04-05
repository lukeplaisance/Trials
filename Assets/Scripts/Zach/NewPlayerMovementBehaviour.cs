using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Zach
{
    public class NewPlayerMovementBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _moveVector;
        public Vector3 MoveVector
        {
            get { return _moveVector; }
        }
        public float speed = 5;
        public float jumpPower = 4;
        public float gravity = 9.81f;
        public Vector3 velocity;
        public Vector3 camRight;
        public Vector3 camForward;
        public bool isFrozen = false;
        public bool isGrounded;
        private Vector3 _prevPosition;
        private CharacterController _controller;
        

        private void Start()
        {
            _controller = GetComponent<CharacterController>();
            _prevPosition = transform.position;
            isGrounded = _controller.isGrounded;
        }

        // Update is called once per frame
        private void Update()
        {
            if (!isFrozen)
            {
                var h = PlayerInput.InputVector.normalized.x;
                var v = PlayerInput.InputVector.normalized.z;
                var forward = Camera.main.transform.TransformDirection(Vector3.forward);
                forward.y = 0;
                forward = forward.normalized;
                var right = new Vector3(forward.z, 0, -forward.x);
                var targetDir = h * right + v * forward;
                if (targetDir.magnitude > 0)
                    transform.rotation = Quaternion.LookRotation(targetDir);
                _moveVector.x = targetDir.x;
                _moveVector.z = targetDir.z;
                if(!_controller.isGrounded)
                {
                    _moveVector.y = _moveVector.y - (gravity * Time.deltaTime);
                }
                
                if (_controller.isGrounded)
                {
                    if (Input.GetButtonDown("Jump"))
                    {
                        _moveVector.y = jumpPower;
                    }
                }
                _controller.Move(_moveVector * speed * Time.deltaTime);
            }
            velocity = (transform.position - _prevPosition) / Time.deltaTime;
            _prevPosition = transform.position;
            isGrounded = _controller.isGrounded;
        }
    }
}
//if (!isFrozen)
//{
//    if (_controller.isGrounded)
//    {
//        if (Camera.main != null)
//        {
//            var transform3 = Camera.main.transform;
//            camRight = transform3.right;
//            camForward = transform3.forward;
//        }

//        camForward *= PlayerInput.InputVector.z;
//        camRight *= PlayerInput.InputVector.x;

//        _moveVector = (camForward + camRight);
//        var right = new Vector3(camForward.z, 0, -camForward.x);
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            _moveVector += new Vector3(0, jumpPower, 0);
//        }
//    }

//    transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * 180 * Time.deltaTime);
//    _moveVector.y = _moveVector.y - (gravity * Time.deltaTime);
//    var transform1 = transform;
//    if (Camera.main != null)
//    {
//        var transform2 = Camera.main.transform;
//        var forward = transform2.forward;
//        transform1.forward = new Vector3(forward.x, transform1.forward.y,
//            forward.z);
//    }

//    _controller.Move(_moveVector * speed * Time.deltaTime);
//}