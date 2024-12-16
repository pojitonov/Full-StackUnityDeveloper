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

            Container.BindInterfacesAndSelfTo<SnakeCollectionController>()
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<SnakeDeactivationController>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<SnakeDeathController>()
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<SnakeSizeController>()
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<SnakeSpeedController>()
                .AsSingle();
        }
    }
}