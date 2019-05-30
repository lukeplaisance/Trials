using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Luke
{
    public class AstrolabeBubbleBehaviour : MonoBehaviour
    {

        public AstrolabeActivationandCooldownBehaviour astrolabe_bubble;

        void Start()
        {
            astrolabe_bubble = FindObjectOfType<AstrolabeActivationandCooldownBehaviour>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Animation_Object"))
            {
                astrolabe_bubble.in_range = true;
                astrolabe_bubble.AddFoundAnimationObjectsToList();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            astrolabe_bubble.in_range = false;
            astrolabe_bubble.RemoveFoundAnimationObjects();
        }
    }
}
