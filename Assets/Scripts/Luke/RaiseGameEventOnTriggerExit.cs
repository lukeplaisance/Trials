using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Luke
{
    public class RaiseGameEventOnTriggerExit : MonoBehaviour
    {
        [SerializeField]
        private GameEvent gameEvent;
        public string colliderTag;

        public void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(colliderTag))
            {
                gameEvent.Raise();
            }
        }
    }
}
