using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Zach
{
    public class MovingWallBehaviour : MonoBehaviour
    {
        public bool isMoving;

        [SerializeField] private Vector3 direction;
        [SerializeField] private Vector3 raycastOffset;
        [SerializeField] private float speed;

        private void Update()
        {
            if (isMoving)
                transform.position += direction * speed * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position + raycastOffset, direction * 4, out hit))
                    if (hit.collider.gameObject.CompareTag("Terrain"))
                    {
                        SceneManager.LoadScene("GameOver");
                        Debug.Log("Player is dead.");
                    }
            }

            if (other.CompareTag("Terrain")) isMoving = false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawRay(transform.position + raycastOffset, direction * 4);
        }
    }
}