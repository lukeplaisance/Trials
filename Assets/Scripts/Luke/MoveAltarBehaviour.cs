
using UnityEngine;

namespace Luke
{
    public class MoveAltarBehaviour : MonoBehaviour
    {
        public Animator animator;

        void Start()
        {
            animator.SetBool("Interacted", false);
            animator.SetBool("OnPlatform", false);
        }

        public void MoveAltar()
        {
            animator.SetBool("Interacted", true);
            animator.Play("MoveAltar");
            Debug.Log("altar rising sound should play");
        }

        public void MoveAltarDown()
        {
            animator.SetBool("OnPlatform", true);
            animator.Play("MoveAltarDown");
        }
    }
}
