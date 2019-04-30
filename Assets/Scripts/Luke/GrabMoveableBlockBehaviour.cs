using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using Zach;
using Matthew;


namespace Luke
{
    public class GrabMoveableBlockBehaviour : MonoBehaviour, IGrabbable
    {
        public bool IsGrabbed
        {
            get { return is_grabbed; }
        }
        private bool is_grabbed = false;
        private Transform grabbed_trans;
        public GameObjectVariable player;

        void Update()
        {
            if (is_grabbed)
            {
                player.Value.transform.position = grabbed_trans.position;
            }
        }

        public void GetGrabbed(Transform trans)
        {
            is_grabbed = true;
            FMODUnity.RuntimeManager.PlayOneShot("event:/push_block_interaction_start");
            Debug.Log("pushblock grabbed");
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
              
            }
        }
    }
}
