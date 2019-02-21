using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zach
{
    public class BAD : MonoBehaviour
    {
        public MovingWallBehaviour wall1;

        public MovingWallBehaviour wall2;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                wall1.isMoving = true;
                wall2.isMoving = true;
            }
        }
    }
}
