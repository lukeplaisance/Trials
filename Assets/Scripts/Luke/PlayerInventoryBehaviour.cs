using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

namespace Luke
{
    public class PlayerInventoryBehaviour : MonoBehaviour
    {
        [SerializeField]
        private List<Item> Player_Inventory = new List<Item>();
        public bool has_item = false;

        //void Start()
        //{
        //    Player_Inventory.
        //}

        public void AddItem(Item item)
        {
            Player_Inventory.Add(item);
            Debug.Log("picked up" + item.name);
        }

        public void RemoveItem(Item item)
        {
            if (has_item)
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
