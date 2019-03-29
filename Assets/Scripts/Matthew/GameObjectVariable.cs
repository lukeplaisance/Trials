using System;
using UnityEngine;

namespace Matthew
{
    [CreateAssetMenu]
    public class GameObjectVariable : ScriptableObject
    {
        public string nameOfReference;

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

        public void SetActive(bool flag)
        {
            _referenceGameObject.SetActive(flag);
        }
    }
}