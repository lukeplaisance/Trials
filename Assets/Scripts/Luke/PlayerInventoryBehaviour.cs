using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.Events;

namespace Luke
{
    public class PlayerInventoryBehaviour : MonoBehaviour
    {
        [SerializeField] private PlayerInventoryObject PlayerInventoryScriptableObject;

        public void AddItem(Item item)
        {
            PlayerInventoryScriptableObject.AddItem(item);
        }

        public void RemoveItem(Item item)
        {
            PlayerInventoryScriptableObject.RemoveItem(item);
        }
    }
}
