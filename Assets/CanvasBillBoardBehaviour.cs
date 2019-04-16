using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Matthew;
using UnityEngine;

namespace Luke
{
    public class CanvasBillBoardBehaviour : MonoBehaviour
    {
        public Cinemachine.CinemachineFreeLook freelook_camrea;

        void Update()
        {
            transform.LookAt(freelook_camrea.transform.position);
        }
    }
}
