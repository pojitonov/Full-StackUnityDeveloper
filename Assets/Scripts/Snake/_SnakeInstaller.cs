using Modules;
using Zenject;

namespace SnakeGame
{
    public class _SnakeInstaller : Installer<Snake, _SnakeInstaller>
    {
        [Inject]
        private Snake _snake;

        public override void InstallBindings()
        {
            Container.Bind<ISnake>()
                .FromInstance(_snake)
                .AsSingle();

            Container.BindInterfacesAndSelfTo<SnakeCollectCoinController>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<SnakeSizeController>()
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<SnakeSpeedController>()
                .AsSingle();
        }
    }
}