using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBehaviour : MonoBehaviour
{
    public void MoveBridge()
    {
        var rot = transform.GetChild(0);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot.rotation, 1);
    }
	
}
