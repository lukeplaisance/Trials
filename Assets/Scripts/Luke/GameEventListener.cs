using UnityEngine;
using UnityEngine.Events;

using IListener = Matthew.IListener;

namespace Luke
{
    public class GameEventListener : MonoBehaviour, IListener
    {

        public GameEvent Event;
        [TextArea]
        public string Notes;
        [SerializeField]
        private UnityEvent Response;

        public void OnEventRaised()
        {
            Response.Invoke();
        }

        private void OnEnable()
        {
            Subscribe();
        }

        void OnDisable()
        {
            UnSubscribe();
        }

        public void Subscribe()
        {
            Event.RegisterListener(this);
        }

        public void UnSubscribe()
        {
            Event.UnregisterListener(this);
        }
    }
}