using System.Collections;
using System.Collections.Generic;
using Matthew;
using UnityEngine;
using UnityEngine.Events;
using UnityEngineInternal;


namespace Luke
{
    public class SlowDownObjectAnimationBehaviour : MonoBehaviour
    {
        public Animator animator;
        public GameObjectVariable player;
        public float threshold;
        public bool in_range;
        public UnityEvent Response;

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void SlowDownObjectAnimation(float speed)
        {
            if (in_range)
            {
                animator.speed = speed;
            }
        }

        public void CheckDistanceofPlayer()
        {
            if(Vector3.Distance(gameObject.transform.position, player.Transform.position) < threshold)
            {
                Debug.Log("Player is in range");
                in_range = true;
                SlowDownObjectAnimation(0.5f);
            }
            else
            {
                in_range = false;
                animator.speed = 1;
                return;
            }
        }

        void Update()
        {
            Debug.Log(animator.speed);
            Response.Invoke();
        }
    }
}
