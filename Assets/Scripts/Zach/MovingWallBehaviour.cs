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
        public Vector3 startPos;
        public Vector3 endPos;
        [SerializeField] private Vector3 direction;
        [SerializeField] private Vector3 raycastOffset;
        [SerializeField] private float speed;

        private void Update()
        {
            if (isMoving)
                transform.position += direction * speed * Time.deltaTime;
            if (movingToStart && Vector3.Distance(transform.position,startPos) < 0.1f)
            {
                isMoving = false;
                movingToStart = false;
            }

            if (movingToEnd && Vector3.Distance(transform.position,endPos) < 0.1f)
            {
                isMoving = false;
                movingToEnd = false;
            }
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

            if (other.CompareTag("Terrain") && !IgnoreTerrain) isMoving = false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawRay(transform.position + raycastOffset, direction * 4);
        }

        public void MoveToStart()
        {
            isMoving = true;
            movingToStart = true;
            direction = startPos - transform.position;
        }

        public void MoveToEnd()
        {
            isMoving = true;
            movingToEnd = true;
            direction = endPos - transform.position;
        }
    }
}