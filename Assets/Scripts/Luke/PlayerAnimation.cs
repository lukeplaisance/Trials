using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

namespace Luke
{
    public class PlayerAnimation : MonoBehaviour
    {
        public Animator animator;
        private float v;

        private float h;

        // Use this for initialization
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            v = Input.GetAxis("Vertical");
            h = Input.GetAxis("Horizontal");
            var move = new Vector3(h, 0, v);
            var speed = move.magnitude;
            var Strafe = h;
            animator.SetBool("IsStrafe", Strafe > 0.1 || Strafe < -0.1);
            animator.SetBool("IsMoving", speed > 0.1 || speed < -0.1);

        }

        private void FixedUpdate()
        {
            animator.SetFloat("speed", v);
            animator.SetFloat("Strafe", h);
        }
    }
}
