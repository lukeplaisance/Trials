public interface IContext
{
    void ResetContext();
    IState CurrentState { get; }
    void UpdateContext();
    void ChangeState(IState next);
}
