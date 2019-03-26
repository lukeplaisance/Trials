using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zach;


namespace Luke
{
    public class PushPullBehaviour : MonoBehaviour, IGrabbable
    {
        private bool is_grabbed = false;
        private Transform grabbed_trans;
        public GameObject player;
        public float PlayerSide;

        // Update is called once per frame
        void Update()
        {
            PlayerSide = Vector3.Dot(transform.position - player.transform.position, player.transform.forward);
            if (is_grabbed)
            {
                if(Vector3.Dot(transform.position - player.transform.position, player.transform.forward) > 0.5)
                {
                    player.transform.position = transform.position + new Vector3(0, -1, -1.5f);
                }

                if (Vector3.Dot(transform.position - player.transform.position, transform.forward) < 0)
                {
                    player.transform.position = transform.position + new Vector3(0, 1, -1.5f);
                }
            }
        }

        public void GetGrabbed(Transform trans)
        {
            grabbed_trans = transform;
            is_grabbed = true;
        }

        public void GetDropped()
        {
            is_grabbed = false;
        }
    }
}
