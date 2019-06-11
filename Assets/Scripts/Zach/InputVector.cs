using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zach
{
    public static class PlayerInput
    {
        public static bool PausePressed
        {
            get { return Input.GetButtonDown("Pause"); }
        }
        public static bool SubmitPressed
        {
            get { return Input.GetButtonDown("Submit"); }
        }
        public static bool CancelPressed
        {
            get { return Input.GetButtonDown("Cancel"); }
        }
        public static Vector3 InputVector
        {
            get
            {
                var h = Input.GetAxis("Horizontal");
                var v = Input.GetAxis("Vertical");
                return new Vector3(h, 0, v);
            }
        }
    }
}
