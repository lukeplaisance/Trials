using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Luke
{
    public class OnWaypointEnterBehaviour : MonoBehaviour
    {
        public UnityEvent Response;

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Response.Invoke();
            }
        }
    }
}
