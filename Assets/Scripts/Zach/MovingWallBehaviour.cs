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
        public Rigidbody rb;

        FMOD.Studio.EventInstance slidingDoorsSound;
        FMOD.Studio.EventInstance footstep;
        private FMOD.Studio.PLAYBACK_STATE slidingDoorsSoundPlaybackState;
        private int slidingDoorPlayCalls = 0;
        //bool isPlaying = playbackState != FMOD.Studio.PLAYBACK_STATE.STOPPED;



        private void Start()
        {
            slidingDoorsSound = FMODUnity.RuntimeManager.CreateInstance("event:/hazard_hallway_sliding_doors");
            slidingDoorsSoundPlaybackState = FMOD.Studio.PLAYBACK_STATE.STOPPED;

            footstep = FMODUnity.RuntimeManager.CreateInstance("event:/general_stone_footstep");

            //footstep.start();
            //slidingDoorsSound.start();

            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            slidingDoorsSound.getPlaybackState(out slidingDoorsSoundPlaybackState);
            Debug.Log(slidingDoorsSoundPlaybackState);

           
                
            

            if (isMoving)
                transform.position += direction * speed * Time.deltaTime;

            if (isMoving && slidingDoorPlayCalls == 0)
            {
                //slidingDoorsSound.start();
                FMODUnity.RuntimeManager.PlayOneShot("event:/hazard_hallway_sliding_doors");
                Debug.Log("sliding door sound should be playing");
                slidingDoorPlayCalls++;
            }
            /*if (!isMoving && slidingDoorPlayCalls)
            {
                slidingDoorsSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            }*/
            
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
                rb.constraints = RigidbodyConstraints.FreezeAll;
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