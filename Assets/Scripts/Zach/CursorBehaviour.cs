using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zach
{
    public class CursorBehaviour : MonoBehaviour
    {

        // Use this for initialization
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }

        public void ShowCursor(bool visible)
        {
            Cursor.visible = visible;
        }
    }
}