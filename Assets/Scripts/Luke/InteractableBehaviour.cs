using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Luke
{

    public class InteractableBehaviour : InteractionBehaviour
    {
        public UnityEvent response;
        public Animation animation;
        public GameEvent end;

        // Use this for initialization
        void Start()
        {
            response = _response;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
