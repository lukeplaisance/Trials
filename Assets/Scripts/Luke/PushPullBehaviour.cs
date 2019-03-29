using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Matthew;


namespace Luke
{
    public class PushPullBehaviour : MonoBehaviour
    {
        public float speed;
        public GameObjectVariable player;
        public GrabMoveableBlockBehaviour front_col;
        public GrabMoveableBlockBehaviour back_col;
        public GrabMoveableBlockBehaviour left_col;
        public GrabMoveableBlockBehaviour right_col; 

        public void Start()
        {
          
        }

        void Update()
        {
            var v = Input.GetAxis("Vertical");
            if (front_col.IsGrabbed)
            {
                Move(new Vector3(0, 0, -v));
            }

            if (back_col.IsGrabbed)
            {
                Move(new Vector3(0, 0, v));
            }

            if (left_col.IsGrabbed)
            {
                Move(new Vector3(v, 0, 0));
            }

            if (right_col.IsGrabbed)
            {
                Move(new Vector3(-v, 0, 0));
            }
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
