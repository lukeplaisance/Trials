using UnityEngine;
using UnityEngine.Events;

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
        public UnityEvent PlayerCrushedResponse;

        private int slidingDoorsPlayCalls;

        private void Update()
        {
            if (isMoving)
                transform.position += direction * speed * Time.deltaTime;

            if (isMoving && slidingDoorsPlayCalls == 0)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/hazard_hallway_sliding_doors");
                slidingDoorsPlayCalls++;
            }
            if (!isMoving && slidingDoorsPlayCalls == 1)
            {
                
                slidingDoorsPlayCalls--;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.transform.SetParent(this.transform);
                RaycastHit hit;
                if (Physics.Raycast(transform.position + raycastOffset, direction * 4, out hit))
                    if (hit.collider.gameObject.CompareTag("Terrain"))
                    {
                        PlayerCrushedResponse.Invoke();
                        Debug.Log("Player is dead.");
                    }
            }

            if (other.CompareTag("Terrain") && !IgnoreTerrain || other.CompareTag("Grabbable"))
            {
                isMoving = false;
                movingToStart = false;
                movingToEnd = false;
            }   
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.transform.SetParent(null);
                other.transform.localScale = new Vector3(1,1,1);
            }
            if (!other.CompareTag("Terrain") && other.CompareTag("Grabbable"))
            {
                isMoving = true;
                movingToStart = true;
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