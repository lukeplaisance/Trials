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

        }

        // Update is called once per frame
        private void Update()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }
    }
}