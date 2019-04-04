namespace Matthew
{
    public interface IListener
    {
        void OnEventRaised();

        void Subscribe();
        void UnSubscribe();
    }
}