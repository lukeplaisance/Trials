using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Matthew;
using UnityEngine.Events;
using UnityEngine.Experimental.Audio.Google;


namespace Luke
{
    public class WaypointBehaviour : MonoBehaviour
    {
        public GameObjectVariable player_reference;
        public List<Transform> waypoints;
        public bool is_spawned = false;
        [HideInInspector] public Transform current_waypoint;
        public GameEvent waypoint_reached;
        public UnityEvent Response;


        private void Start()
        {
            Response.Invoke();
        }

        public void SpawnPlayer(Transform waypoint)
        {
            Instantiate(player_reference);
            is_spawned = true;
            player_reference.Value.transform.position = waypoint.position;
        }

        public void MoveCurrentWaypoint()
        {
            for (int i = 0; i < waypoints.Count; i++)
            {
                if (current_waypoint == null)
                {
                    current_waypoint = waypoints[0];
                }
                else
                {
                    current_waypoint = waypoints[i];
                }
                Debug.Log("current waypoint is " + current_waypoint.gameObject.name);
            }
        }
    }
}
