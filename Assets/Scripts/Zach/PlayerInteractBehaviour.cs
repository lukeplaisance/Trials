using System.Collections;
using System.Collections.Generic;
using Luke;
using UnityEngine;

namespace Zach
{
    public class PlayerInteractBehaviour : InteractorBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && currentInteraction != null)
            {
                currentInteraction.Interact(this);
            }
        }
    }
}
