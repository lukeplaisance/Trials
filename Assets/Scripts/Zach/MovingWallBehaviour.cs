using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Zach
{
    public class MovingWallBehaviour : MonoBehaviour
    {
        public bool isMoving;
        public bool IgnoreTerrain;
        public bool movingToStart;
        public bool movingToEnd;
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

            if (other.CompareTag("Terrain") && !IgnoreTerrain) 
            {
                isMoving = false;
                movingToStart = false;
                movingToEnd = false;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawRay(transform.position + raycastOffset, direction * 4);
        }

        public void MoveToStart()
        {
            isMoving = true;
            movingToStart = true;
            movingToEnd = false;
            direction = -direction;
            Debug.Log("moving");
        }

        public void MoveToEnd()
        {
            isMoving = true;
            movingToEnd = true;
            movingToStart = false;
            direction = -direction;
        }
    }
}