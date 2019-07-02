using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zach;

namespace Zach
{
    public class PressBToClose : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if (PlayerInput.CancelPressed)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}