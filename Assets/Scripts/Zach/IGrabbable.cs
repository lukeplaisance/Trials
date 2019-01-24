using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGrabbable
{
    void GetGrabbed(Transform trans);
    void GetDropped();
}