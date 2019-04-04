using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Brett
{
    public class NpcBehaviour : MonoBehaviour
    {
        public Transform Target;
        public float AngleOfView;
        public float DistanceOfView;
        public bool IsDead;
        public bool RightShoulderGrabbed;
        public bool LeftShoulderGrabbed;
        private Animator _anim;
        private RaycastHit _hit;

        private void Start()
        {
            _anim = GetComponent<Animator>();
            IsDead = false;
        }

        private void Update()
        {

            PlayerDetection();

            //if (Input.GetKey(KeyCode.A))
            //{
            //    leftShoulderGrabbed = true;
            //}
            //else
            //{
            //    leftShoulderGrabbed = false;
            //}
            //if (Input.GetKey(KeyCode.D))
            //{
            //    rightShoulderGrabbed = true;
            //}
            //else
            //{
            //    rightShoulderGrabbed = false;
            //}
            if (Input.GetKey(KeyCode.Space))
            {
                IsDead = true;
                _anim.SetBool("isDead", true);
            }
        }

        public bool ICanSeeThePlayer = false;

        void PlayerDetection()
        {
            var targetDir = Target.position - transform.position;
            float angle = Vector3.Angle(targetDir, transform.forward);
            float distance = Vector3.Distance(Target.position, transform.position);
            print(distance + ": between target and npc");
            if (angle <= AngleOfView && distance <= DistanceOfView)
            {
                Debug.DrawLine(transform.position, Target.transform.position, Color.blue);
                if (Physics.Linecast(transform.position, Target.transform.position, out _hit))
                {
                    if (_hit.collider.CompareTag("Player"))
                    {
                        print("NPC can see player");
                        ICanSeeThePlayer = true;
                    }
                    else
                    {
                        ICanSeeThePlayer = false;
                    }
                }
            }
        }
    }
}