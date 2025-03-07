namespace Modules.FSM
{
    public interface IState
    {
        void OnEnter();

        void OnUpdate(float deltaTime);

        void OnExit();
    }
}