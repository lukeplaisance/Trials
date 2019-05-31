using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Luke
{
    public class AstrolabeBehaviour : MonoBehaviour
    {
        public GameEvent Activate_Astrolabe;
        public GameEvent Cooldown_Astrolabe;

        public UnityEvent Activate;

        void Update()
        {
            if (Input.GetButtonDown("Fire4"))
            {
                Activate.Invoke();
                Debug.Log(Activate_Astrolabe + "Raised");
            }
        }

        void OnDisable()
        {
            Debug.Log(Cooldown_Astrolabe + "Raised");
        }
    }
}
