﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Matthew;


namespace Luke
{
    public class PushPullBehaviour : MonoBehaviour
    {
        public float speed;
        public CharacterController _controller;

        //changed from gameobjects to grabmoveableblockbehaviours
        public GrabMoveableBlockBehaviour front_col;
        public GrabMoveableBlockBehaviour back_col;
        public GrabMoveableBlockBehaviour left_col;
        public GrabMoveableBlockBehaviour right_col;
        public bool isColliding = false;
        GameObjectVariable PlayerRef;
        Animator PlayerAnimator;
        private void Start()
        {
            PlayerRef = Resources.Load("References/PlayerStaticReference") as GameObjectVariable;
            PlayerRef.OnValueChanged.AddListener(() => PlayerAnimator = PlayerRef.Value.GetComponent<Animator>());
           
        }
        
        void Update()
        {
            //now checking for if the collider is grabbed rather than positional check
            var v = Input.GetAxis("Vertical");
            
            if (front_col.IsGrabbed)
            {
                if (!isColliding)
                {
                    PlayerAnimator.SetFloat("PushSpeed", v);
                    _controller.Move(new Vector3(0, 0, -v) * speed * Time.deltaTime);
                }
            }

            if (back_col.IsGrabbed)
            {
                if (!isColliding)
                {
                    PlayerAnimator.SetFloat("PushSpeed", v);
                    _controller.Move(new Vector3(0, 0, v) * speed * Time.deltaTime);
                }
            }

            if (left_col.IsGrabbed)
            {
                if (!isColliding)
                {
                    PlayerAnimator.SetFloat("PushSpeed", v);
                    _controller.Move(new Vector3(v, 0, 0) * speed * Time.deltaTime);
                }
            }

            if (right_col.IsGrabbed)
            {
                if (!isColliding)
                {
                    PlayerAnimator.SetFloat("PushSpeed", v);
                    _controller.Move(new Vector3(-v, 0, 0) * speed * Time.deltaTime);
                }
            }

        }
    }
}
