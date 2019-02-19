using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zach
{
    public class BlockBehaviour : MonoBehaviour, IGrabbable
    {
        private bool _grabbed = false;
        Transform _grabTrans;

        public void GetDropped()
        {
            _grabbed = false;
            var box = GetComponent<BoxCollider>();
            box.enabled = true;
        }

        public void GetGrabbed(Transform trans)
        {
            _grabbed = true;
            var box = GetComponent<BoxCollider>();
            box.enabled = false;
            _grabTrans = trans;
        }

        private void Start()
        {

        }

        private void Update()
        {
            if (_grabbed)
            {
                transform.position = _grabTrans.position;
            }
        }
    }
}