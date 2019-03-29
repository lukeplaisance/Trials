using System;
using UnityEngine;

namespace Matthew
{
    [CreateAssetMenu]
    public class GameObjectVariable : ScriptableObject
    {
        public string nameOfReference;

        [NonSerialized] public GameObject ReferenceGameObject; //set this in inspector

        public GameObject Value
        {
            get { return ReferenceGameObject; }
            set
            {
                ReferenceGameObject = value;
                nameOfReference = ReferenceGameObject.name;
            }
        }

        public void SetActive(bool flag)
        {
            ReferenceGameObject.SetActive(flag);
        }
    }
}