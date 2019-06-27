using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using UnityEngine;

namespace Luke
{
    public class PressurePlateTriggerBehaviour : MonoBehaviour
    {
        public Animator animator;
        public string pressure_plate_up;
        public string pressure_plate_down;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Grabbable") || other.CompareTag("Player"))
            {
                animator.SetBool("IsDown", true);
                animator.Play(pressure_plate_down);
                Debug.Log("pressure plate sound should play");
                FMODUnity.RuntimeManager.PlayOneShot("event:/pressure_plate");
            }
            
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Grabbable") || other.CompareTag("Player"))
            {
                animator.SetBool("IsDown", false);
                animator.Play(pressure_plate_up);
            }
        }
    }
}
