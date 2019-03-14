using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Luke
{
    public class CombinationLockBehaviour : MonoBehaviour
    {
        private List<int> answer = new List<int> {3, 2, 4,};
        public List<Slot> Slots;
        [SerializeField] public bool isLocked = true;
        Color Default;

        public GameObject door;

        private void Start()
        {
            for (var i = 0; i < Slots.Count; i++)
            {
                Slots[i].rend = Slots[i].GetComponent<MeshRenderer>();
                Default = Slots[i].GetComponent<MeshRenderer>().material.color;
            }
        }



        // Update is called once per frame
        void Update()
        {
            CheckValues();
            OpenDoor(Vector3.up);
        }

        public void CheckValues()
        {
            isLocked = false;
            for (int i = 0; i < Slots.Count; i++)
            {
                if (Slots[i].current_value == answer[i])
                    Slots[i].rend.material.color = Color.green;
                else
                {
                    Slots[i].rend.material.color = Default;
                    isLocked = true;
                }
            }
        }

        //method to test opening a door when the lock is unlocked
        public void OpenDoor(Vector3 direction)
        {
            float speed = 2;
            if (isLocked == false)
            {
                door.transform.position += direction * speed * Time.deltaTime;
            }
        }
    }
}
