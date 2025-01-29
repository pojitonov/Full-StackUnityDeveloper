using Atomic.Contexts;

namespace Game.Gameplay
{
    public interface IGameContext : IContext
    {
    }
    public class GameContext : SingletonSceneContext<GameContext>, IGameContext
    {
         
    }
}