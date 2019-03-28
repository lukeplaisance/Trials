using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using Zach;


namespace Luke
{
    public class GrabMoveableBlockBehaviour : MonoBehaviour, IGrabbable
    {
        private bool is_grabbed = false;
        private Transform grabbed_trans;
        public GameObject player;

        void Update()
        {
            if (is_grabbed)
            {
                player.transform.position = grabbed_trans.position;
            }
        }

        public void GetGrabbed(Transform trans)
        {
            is_grabbed = true;
            grabbed_trans = trans;
        }

        public void GetDropped()
        {
            is_grabbed = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Update();
            }
        }
    }
}
