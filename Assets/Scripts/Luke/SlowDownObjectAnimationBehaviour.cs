using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Luke
{
    public class SlowDownObjectAnimationBehaviour : MonoBehaviour
    {
        public Animator animator;

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void SlowDownObjectAnimation()
        {
            animator.speed = (animator.speed / 2);
        }
    }
}
