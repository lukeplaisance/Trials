using UnityEngine;

namespace Matthew
{
    public class SetStaticReferenceBehaviour : MonoBehaviour //use this behaviour to set a static gameobject reference
    {
        public GameObjectVariable gameObjectReferencer;

        // Use this for initialization
        private void Awake()
        {
            gameObjectReferencer.Value = gameObject;
            Debug.Log("NOTE POPUP SOUND");
        }
    }
}