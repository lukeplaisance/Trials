using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Luke
{
    public class RaiseGameEventOnTriggerEnter : MonoBehaviour
    {

        [SerializeField]
        private GameEvent gameEvent;
        public string colliderTag;

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(colliderTag))
            {
                gameEvent.Raise();
            }
        }
    }
}
