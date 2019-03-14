using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Luke
{
    public class SlotButtonBehaviour : MonoBehaviour
    {
        public GameObject slotButton;
        public UnityEvent OnClick = new UnityEvent();

        // Use this for initialization
        void Start()
        {
            slotButton = gameObject;
        }

        // Update is called once per frame
        void Update()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
                {
                    Debug.Log("Button Clicked");
                    OnClick.Invoke();
                }
            }
        }
    }
}
