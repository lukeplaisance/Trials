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
        public Object DisableRequestor;
        public void DisableMovementRequest(Object obj)
        {
            DisableRequestor = obj;
            PlayerReference.Value.GetComponent<PlayerStateBehaviour>().SetMovement(false);
        }

        public void EnableMovementRequest(Object obj)
        {
            if(obj != DisableRequestor)
            {
                Debug.LogWarning("the object that is enabling the movement is not the object that disabled it");
            }
            PlayerReference.Value.GetComponent<PlayerStateBehaviour>().SetMovement(true);
        }

        public void PrintInfo(string value)
        {
            Debug.Log("GlobalBlackBoard:: " + value);
        }
    }
}