public interface IState
{
    void OnEnter(IContext context);
    void UpdateState(IContext context);
    void OnExit(IContext context);
}