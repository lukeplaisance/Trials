namespace Matthew
{
    public interface ISubscribeable 
    {
        void RegisterListener(IListener listener);
        void UnregisterListener(IListener listener);
    }
}