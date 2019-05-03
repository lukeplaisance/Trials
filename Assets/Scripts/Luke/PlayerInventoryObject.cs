using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Luke
{
    [CreateAssetMenu]
    public class PlayerInventoryObject : ScriptableObject
    {

        private List<Item> Player_Inventory;

        public bool has_item;

        void OnEnable()
        {
            has_item = false;
            Player_Inventory = new List<Item>();
        }
        public void AddItem(Item item)
        {
            Player_Inventory.Add(item);
            Debug.Log("picked up" + item.name);
        }

        public void RemoveItem(Item item)
        {
            if (Player_Inventory.Contains(item))
            {
                Player_Inventory.Remove(item);
                Debug.Log("dropped" + item.name);
            }
        }
         
        public void CheckForItem(Item item)
        {
            if (Player_Inventory.Contains(item))
            {
                has_item = true;
            }
        }
    }
}
