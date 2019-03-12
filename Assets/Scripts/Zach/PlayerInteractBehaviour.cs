using System.Collections;
using System.Collections.Generic;
using Luke;
using UnityEngine;

namespace Zach
{
    public class PlayerInteractBehaviour : InteractorBehaviour
    {
        public GameEvent interactStart;
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactStart.Raise();
            }
        }
    }
}
