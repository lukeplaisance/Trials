using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Serialization;

namespace Zach
{
    public class NewPlayerMovementBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _moveVector = Vector3.zero;
        private Vector3 _prevMoveVector;
        public Vector3 MoveVector
        {
            get { return _moveVector; }
            set { _moveVector = value; }
        }
        public float speed = 5;
        private float baseSpeed;
        public float jumpPower = 4;
        public float gravity = 9.81f;
        public float mag;
        public float _magExponent;
        public Vector3 velocity;
        public Vector3 camRight;
        public Vector3 camForward;
        public bool isFrozen = false;
        public Vector3 forward;
        public Vector3 targetDir;

        public static bool IsGrounded
        {
            get { return isGrounded; }
        }
        private static bool isGrounded;
        private Vector3 _prevPosition;
        private CharacterController _controller;
        private Animator _animator;
        

        private void Start()
        {
            baseSpeed = speed;
            _prevPosition = transform.position;
            _controller = GetComponent<CharacterController>();
            isGrounded = _controller.isGrounded;
            _animator = GetComponent<Animator>();
            mag = PlayerInput.InputVector.magnitude;
        }

        // Update is called once per frame
        private void Update()
        {
            velocity = (transform.position - _prevPosition) / Time.deltaTime;
            _animator.SetFloat("Velocity", _controller.velocity.magnitude);
            _prevPosition = transform.position;
            isGrounded = _controller.isGrounded;
            _animator.SetBool("IsGrounded", isGrounded);
            speed = baseSpeed;
            mag = PlayerInput.InputVector.magnitude;

            //If player is frozen don't execute any of the movement code
            if (isFrozen)
                return;

            //If the magnitude of the joystick is greater than the deadzone and the exponent
            //is less than the magnitude then ramp the exponent up so the player doesn't instantly
            //reach full speed
            var prevX = _moveVector.x;
            var prevZ = _moveVector.z;
            if (mag > 0.20f)
            {
                if (_magExponent < mag)
                    _magExponent += (Time.deltaTime*1.5f);
            }
            if (mag < _magExponent)
            {
                if (_magExponent > 0)
                {
                    _magExponent -= Time.deltaTime;
                }
            }
            var h = PlayerInput.InputVector.normalized.x;
            var v = PlayerInput.InputVector.normalized.z;
            //set the camera's x rotation to 0 so we can ignore it when calculating the angle the player moves
            var trans = Camera.main.transform;
            var vec = trans.rotation.eulerAngles;
            vec.x = 0;
            Camera.main.transform.rotation = Quaternion.Euler(vec);
            forward = Camera.main.transform.TransformDirection(Vector3.forward);
            forward.y = 0;
            var right = new Vector3(forward.z, 0, -forward.x);
            targetDir = h * right + v * forward;
            if (targetDir.magnitude > 0)
            {
                var rot = Quaternion.Euler(targetDir);
                transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(targetDir),0.25f);
            }
            //Give the moveVector the direction the player should move when they press forward.
            //We don't set the Y because it would break the jump
            _moveVector.x = targetDir.x;
            _moveVector.z = targetDir.z;
            //If the player isn't grounded then apply gravity
            if (!_controller.isGrounded)
            {
                _moveVector.y = _moveVector.y - (gravity * Time.deltaTime);
            }

            if (_controller.isGrounded)
            {
                _moveVector.y = -0.5f;
            }
            
            //If the player pushes the jump button and is grounded then set the move vector to the jump value
            //and trigger the jump animation
            if (_controller.isGrounded && Input.GetButtonDown("Jump"))
            {
                _moveVector.y = jumpPower;
                _animator.SetTrigger("OnJump");
            }
            //Apply the speed
            speed *= _magExponent;
            if (_moveVector.x == 0 && _moveVector.z == 0 && _magExponent > 0.20f)
            {
                _moveVector.x = (prevX * _magExponent);
                _moveVector.z = (prevZ * _magExponent);
            }
            else
            {
                _moveVector.x *= speed;
                _moveVector.z *= speed;
            }
            _controller.Move(_moveVector * Time.deltaTime);
        }
    }
}