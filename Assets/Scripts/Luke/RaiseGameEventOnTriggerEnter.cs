using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace Luke
{
    public class RaiseGameEventOnTriggerEnter : MonoBehaviour
    {

        [SerializeField]
        private GameEvent gameEvent;
        public List<string> TargetColliderTags = new List<string>();

        public void OnTriggerEnter(Collider other)
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
