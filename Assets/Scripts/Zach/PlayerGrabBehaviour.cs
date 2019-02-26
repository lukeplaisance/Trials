using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zach
{
    public class PlayerGrabBehaviour : MonoBehaviour, IGrabber
    {
        public Transform grabbedObjectPos;
        private BlockBehaviour _grabit;
        private bool _objectGrabbed = false;

        public void Grab(IGrabbable grabbable)
        {
            grabbable.GetGrabbed(grabbedObjectPos);
        }

        public void Drop(IGrabbable grabbable)
        {
            grabbable.GetDropped();
        }

        private void Update()
        {
            RaycastHit hit;
            if (Input.GetButtonDown("Fire2") && _objectGrabbed)
            {
                Drop(_grabit);
                _grabit = null;
                _objectGrabbed = false;
            }
            else if (Physics.Raycast(transform.position, transform.forward, out hit, 5))
            {
                if (hit.collider.gameObject.CompareTag("Grabbable") && Input.GetButtonDown("Fire2"))
                {
                    if (!_objectGrabbed)
                    {
                        _grabit = hit.collider.gameObject.GetComponent<BlockBehaviour>();
                        Grab(_grabit);
                        _objectGrabbed = true;
                    }

                }

            }

        }

        private void OnDrawGizmos()
        {
            var transform1 = transform;
            Gizmos.DrawRay(transform1.position, transform1.forward * 5);
        }
    }
}