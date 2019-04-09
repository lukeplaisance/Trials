using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Luke
{
    public class PressurePlateTriggerBehaviour : MonoBehaviour
    {
        public Animator animator;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") || other.CompareTag("Grabbable"))
            {
                animator.SetBool("IsDown", true);
                animator.Play("MovePressurePlateDown");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player") || other.CompareTag("Grabbable"))
            {
                animator.SetBool("IsDown", false);
                animator.Play("MovePressurePlateUp");
            }
        }
    }
}
