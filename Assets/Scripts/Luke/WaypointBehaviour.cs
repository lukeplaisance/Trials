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
        private Transform current_waypoint;
        public GameEvent waypoint_reached;
        public UnityEvent Response;


        private void Start()
        {
            Response.Invoke();
        }

        public void SpawnPlayer(Transform waypoint)
        {
            Instantiate(player_reference, waypoint.position, Quaternion.identity);
            is_spawned = true;
        }

        private int currentWayPointIndex = 0;
        public void MoveCurrentWaypoint()
        {
            if (currentWayPointIndex >= waypoints.Count)
            {
                currentWayPointIndex = 0;
                return;
            }
            currentWayPointIndex += 1;
        }

        public void SetCurrentWaypointTransform(Transform waypoint)
        {
            current_waypoint = waypoint;
        }
    }
}
