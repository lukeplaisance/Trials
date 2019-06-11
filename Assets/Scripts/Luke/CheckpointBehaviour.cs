using System.Collections;
using System.Collections.Generic;
using System.IO;
using Matthew;
using UnityEngine;

namespace Luke
{
    public class CheckpointBehaviour : MonoBehaviour
    {
        public WaypointBehaviour waypoint_controller;

        public void Save()
        {
            var current_checkpoint = waypoint_controller.CurrentWaypoint;
            var path = System.IO.Path.Combine(Application.streamingAssetsPath, "checkpoint.json");
            var json = JsonUtility.ToJson(current_checkpoint);
            File.WriteAllText(path, json);
        }

        public void Load()
        {
            var current_checkpoint = waypoint_controller.CurrentWaypoint;
            var path = System.IO.Path.Combine(Application.streamingAssetsPath, this.ToString() + "checkpoint.json");
            var data = File.ReadAllText(path);
            current_checkpoint = JsonUtility.FromJson<Transform>(data);
        }
    }
}
