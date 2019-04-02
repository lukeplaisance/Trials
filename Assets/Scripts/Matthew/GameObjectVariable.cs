using System;
using UnityEngine;

namespace Matthew
{
    [CreateAssetMenu]
    public class GameObjectVariable : ScriptableObject
    {
        public string nameOfReference; //name of the referenced object

        [NonSerialized] private GameObject _referenceGameObject; //set this in inspector//worst comment ever this is a lie

        public GameObject Value
        {
            get
            {
                if (_referenceGameObject == null)
                {
                    Debug.LogWarning("the attempted reference on " + _referenceGameObject.name + " could not be found");                 
                }
                    
                return _referenceGameObject;
            }
            set
            {
                _referenceGameObject = value;
                nameOfReference = _referenceGameObject.name;
            }
        }

        public Transform Transform
        {
            get { return Value.transform; }
        }
        /// <summary>
        /// Sets the Object Active
        /// </summary>
        /// <param name="flag">true for active</param>
        public void SetActive(bool flag)
        {
            if (_referenceGameObject == null)
                Debug.Log(name + " is null when attempting to setactive");
            _referenceGameObject.SetActive(flag);
        }
    }
}