

namespace Matthew
{
    /// <summary>
    /// Use this class to create an instance of a listener to dynamically listen for events that
    /// are broadcast at runtime
    /// </summary>
    public class StateEventTransitionSubscription : IListener
    {
        private ISubscribeable _subscribeable;

        public ISubscribeable Subscribeable
        {
            get
            {
                return _subscribeable;
            }
            set
            {
                _subscribeable = value;
                Subscribe();
            }
        }

        /// <summary>
        /// When the event is raised this property will be true
        /// this must be checked every frame or frequently
        /// typically in update
        /// </summary>
        public bool EventRaised { get; private set; }

        /// <summary>
        /// subscribe to the event
        /// </summary>
        public void Subscribe()
        {
            Subscribeable.RegisterListener(this);
        }

        public void UnSubscribe()
        {
            Subscribeable.UnregisterListener(this);
        }

        /// <summary>
        /// This simply sets the eventraised property to true when the event fires
        /// </summary>
        public void OnEventRaised()
        {
            EventRaised = true;
        }
    }
}
