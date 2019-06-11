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
        public GameEvent BlockInteractionStart;
        public GameEvent BlockInteractionStop;
        void Start()
        {
            BlockInteractionStart = Resources.Load("Events/BlockInteractionStart")as GameEvent;
            BlockInteractionStop = Resources.Load("Events/BlockInteractionStop") as GameEvent;
        }
        void Update()
        {
            if (is_grabbed)
            {
                var playery = player.Value.transform.position.y;
                player.Value.transform.position = new Vector3(grabbed_trans.position.x, playery, grabbed_trans.position.z);
                player.Value.transform.forward = grabbed_trans.forward;
            }
        }

        public void GetGrabbed(Transform trans)
        {
            is_grabbed = true;
            FMODUnity.RuntimeManager.PlayOneShot("event:/push_block_interaction_start");
            grabbed_trans = trans;
            BlockInteractionStart.Raise();

        }

        public void GetDropped()
        {
            is_grabbed = false;
            BlockInteractionStop.Raise();
        }
    }
}
