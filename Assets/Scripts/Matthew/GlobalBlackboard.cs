using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Matthew
{
    [CreateAssetMenu]
    public class GlobalBlackboard : ScriptableObject
    {
        [SerializeField]
        GameObjectVariable PlayerReference;
        public void InstantiateObject(GameObject prefab)
        {
            Instantiate(prefab);
        }
        public void SetPlayerPosition(Transform transform)
        {
            PlayerReference.Transform.position = transform.position;
        }
    }
}