using Modules;
using Zenject;

namespace SnakeGame
{
    public class SnakeInstaller : Installer<Snake, SnakeInstaller>
    {
        [Inject]
        private Snake _snake;

        public override void InstallBindings()
        {
            Container.Bind<ISnake>()
                .FromInstance(_snake)
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<SnakeManager>()
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<CollisionManager>()
                .AsSingle();
        }
    }
}