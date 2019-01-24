using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGrabber
{
    void Grab(IGrabbable grabbable);
    void Drop(IGrabbable grabbable);
}
