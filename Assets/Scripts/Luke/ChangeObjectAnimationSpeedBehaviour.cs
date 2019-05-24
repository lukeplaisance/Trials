using System.Collections;
using System.Collections.Generic;
using Matthew;
using UnityEngine;
using UnityEngine.Events;
using UnityEngineInternal;


namespace Luke
{
    public class ChangeObjectAnimationSpeedBehaviour : MonoBehaviour
    {
        public Animator animator;
        public GameObjectVariable player; //static reference to the playre prefab
        public float animation_speed; //cut the speed in half
        public bool in_range;
        public UnityEvent play_animation;

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

        public void ReturnObjectAnimationSpeed()
        {
            animator.speed = 1;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Astrolabe"))
            {
                Debug.Log("Player is in range");
                in_range = true;
                SlowDownObjectAnimation(animation_speed);
            }
        }

        void OnTriggerExit(Collider other)
        {
            in_range = false;
            animator.speed = 1;
            return;
        }

        void Update()
        {
            Debug.Log(animator.speed);
            play_animation.Invoke();
        }
    }
}
