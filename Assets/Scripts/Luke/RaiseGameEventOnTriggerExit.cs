using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Luke
{
    public class RaiseGameEventOnTriggerExit : MonoBehaviour
    {
        [SerializeField]
        private GameEvent gameEvent;
        public List<string> TargetColliderTags = new List<string>();

        public void OnTriggerExit(Collider other)
        {
            TargetColliderTags.ForEach(x =>
            {
                if (other.CompareTag(x))
                {
                    gameEvent.Raise();
                }
            });
        }
    }
}
