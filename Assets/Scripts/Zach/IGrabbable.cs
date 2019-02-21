using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zach
{
    public interface IGrabbable
    {
        void GetGrabbed(Transform trans);
        void GetDropped();
    }
}