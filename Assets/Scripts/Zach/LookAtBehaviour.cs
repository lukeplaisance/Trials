using UnityEngine;

namespace Zach
{
    public class LookAtBehaviour : MonoBehaviour
    {
        public Transform target;

        // Update is called once per frame
        private void Update()
        {
            transform.LookAt(target);
        }
    }
}