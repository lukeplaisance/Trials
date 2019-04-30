
using UnityEngine;

namespace Luke
{
    public class MoveAltarBehaviour : MonoBehaviour
    {
        public Animator animator;

        void Start()
        {
            animator.SetBool("Interacted", false);
        }

        public void MoveAltar()
        {
            animator.SetBool("Interacted", true);
            animator.Play("MoveAltar");
            Debug.Log("altar rising sound should play");
        }
    }
}
