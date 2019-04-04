using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Brett
{
    public class GameEventListener : MonoBehaviour
    {

        public GameEvent Event;
        [TextArea] public string Notes;
        [SerializeField] private UnityEvent Response;

        public void OnEventRaised()
        {
            Response.Invoke();
        }

        private void OnEnable()
        {
            Event.Subscribe(this);
        }

        private void OnDisable()
        {
            Event.UnSubscribe(this);
        }
    }
}
