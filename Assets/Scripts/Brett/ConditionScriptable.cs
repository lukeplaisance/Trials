using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Brett
{
    [CreateAssetMenu]
    public class ConditionScriptable : ScriptableObject
    {
        public List<Condition> conditions = new List<Condition>();

        private void OnEnable()
        {

            var events = AssetDatabase.FindAssets("t:GameEvent").Select(guid => AssetDatabase.GUIDToAssetPath(guid))
                .Select(path => AssetDatabase.LoadAssetAtPath<GameEvent>(path)).Where(gameevent => gameevent).ToList();

            foreach (var e in events)
            {
                conditions.Add(new Condition{isRaised = false, name = e.name});
            }
        }

        public void Toggle(string name)
        {
            for (int i = 0; i < conditions.Count; i++)
            {
                if (conditions[i].name == name)
                {
                    conditions[i].isRaised = !conditions[i].isRaised;
                }
            }
            
        }
    }

    public class Condition
    {
        public string name;
        public bool isRaised;
    }

}
