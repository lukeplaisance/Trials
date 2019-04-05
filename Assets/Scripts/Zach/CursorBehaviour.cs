using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zach
{
    public class CursorBehaviour : MonoBehaviour
    {
     
        

        public void ShowCursor(bool visible)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = visible;
        }
    }
}