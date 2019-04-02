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
            get { return _referenceGameObject; }
            set
            {
                _referenceGameObject = value;
                nameOfReference = _referenceGameObject.name;
            }
        }


        /// <summary>
        /// Sets the Object Active
        /// </summary>
        /// <param name="flag">true for active</param>
        public void SetActive(bool flag)
        {
            _referenceGameObject.SetActive(flag);
        }
    }
}