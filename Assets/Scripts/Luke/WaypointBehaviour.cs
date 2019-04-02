
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



namespace Luke
{
    public class WaypointBehaviour : MonoBehaviour
    {
        public List<Transform> waypoints;
        private Transform _current_waypoint;
        public UnityEvent startResponse;
        public Matthew.GameObjectVariable PlayerReference;


        private void Start()
        {
            startResponse.Invoke();
        }

        private int currentWayPointIndex = 0;

        public void SetCurrentWaypointTransform(Transform waypoint)
        {
            if (waypoints.Contains(waypoint))
            {
                _current_waypoint = waypoint;
                currentWayPointIndex = waypoints.IndexOf(_current_waypoint);
                return;
            }
            Debug.LogError("attempt to assign a waypoint not in the circuit");

        }

        public void Teleport()
        {
            PlayerReference.Transform.position = _current_waypoint.position;
        }

        
        public void MoveNext()
        {
            int currentIndex = waypoints.IndexOf(_current_waypoint);
            int nextIndex = currentIndex + 1 >= waypoints.Count  ? 0:currentIndex + 1;
            SetCurrentWaypointTransform(waypoints[nextIndex]);
            Teleport();
            
        }
    }


#if UNITY_EDITOR
    [UnityEditor.CustomEditor(typeof(WaypointBehaviour))]
    public class WaypointBehaviourInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var mt = target as WaypointBehaviour;
            base.OnInspectorGUI();
            if (GUILayout.Button("Teleport"))
            {             
                mt.Teleport();
            }
            if (GUILayout.Button("MoveNext"))
            {             
                mt.MoveNext();
            }
        }
    }
#endif
}