using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Luke
{
    public class PlayAnimationBehaviour : MonoBehaviour
    {
        public Animation animation;

        private void Start()
        {
            animation = new Animation();
        }

        public void PlayAnimation()
        {
            animation.Play();
        }

        public void StopAnimation()
        {
            animation.Stop();
        }
    }
}
