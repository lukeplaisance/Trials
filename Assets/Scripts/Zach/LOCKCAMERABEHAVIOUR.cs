using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Luke;
using UnityEngine.Serialization;

namespace Zach
{
    public class LOCKCAMERABEHAVIOUR : MonoBehaviour
    {
        public GameObject lockCam;
        public GameObject otherCam;
        public NewPlayerMovementBehaviour player;

        public CombinationLockBehaviour comboLock;

        // Use this for initialization
        private void Start()
        {
            Cursor.visible = false;
        }

        // Update is called once per frame
        private void Update()
        {
            if (comboLock.isLocked == false)
            {
                lockCam.SetActive(false);
                otherCam.SetActive(true);
                player.isFrozen = false;
                Cursor.visible = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                lockCam.SetActive(true);
                otherCam.SetActive(false);
                Cursor.visible = true;
                player.isFrozen = true;
                Cursor.visible = true;
            }
        }
    }
}
