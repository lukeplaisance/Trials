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
        public UnityEvent play_animation;

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        void Update()
        {
         //   Debug.Log(animator.speed);
            play_animation.Invoke();
        }
    }
}
