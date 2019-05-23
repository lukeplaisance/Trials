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
        public GameObjectVariable player; //static reference to the playre prefab
        public float threshold; //threshold of the radius of the player
        public float animation_speed; //cut the speed in half
        public bool in_range;

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
            var distance = Vector3.Distance(gameObject.transform.position, player.Transform.position);
            if (distance < threshold)
            {
                Debug.Log("Player is in range");
                in_range = true;
                SlowDownObjectAnimation(animation_speed);
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
            CheckDistanceofPlayer();
        }
    }
}
