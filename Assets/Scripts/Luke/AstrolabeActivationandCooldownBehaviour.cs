using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Luke
{
    public class AstrolabeActivationandCooldownBehaviour : MonoBehaviour
    {
        public UnityEvent Activate;

        public float animation_speed;
        public bool in_range;
        private ChangeObjectAnimationSpeedBehaviour[] found_objects;
        [SerializeField] private List<ChangeObjectAnimationSpeedBehaviour> object_list;


        void Start()
        {
            found_objects = FindObjectsOfType<ChangeObjectAnimationSpeedBehaviour>();
        }

        void Update()
        {
            if (Input.GetButtonDown("Fire4"))
            {
                Activate.Invoke();
            }
        }

        public void AddFoundAnimationObjectsToList()
        {
            foreach (var obj in found_objects)
            {
                object_list.Add(obj);
            }

            foreach (var obj in object_list)
            {
                if (in_range)
                {
                    obj.SlowDownObjectAnimation(animation_speed);
                }
            }
        }

        public void RemoveFoundAnimationObjects()
        {
            foreach (var obj in object_list)
            {
                obj.ReturnObjectAnimationSpeed();
            }

            foreach (var obj in found_objects)
            {
                object_list.Remove(obj);
            }

        }
    }
}
