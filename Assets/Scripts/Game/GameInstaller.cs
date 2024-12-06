using Modules;
using Zenject;

namespace SnakeGame
{
    public class GameInstaller : Installer<int, GameInstaller>
    {
        [Inject]
        private int _maxLevels;

        public override void InstallBindings()
        {
            //Modules:
            Container.Bind<IScore>()
                .To<Score>()
                .AsSingle();
            Container.Bind<IGameUI>()
                .To<GameUI>()
                .FromComponentInHierarchy()
                .AsSingle();
            Container.BindInterfacesAndSelfTo<Difficulty>()
                .AsSingle()
                .WithArguments(_maxLevels);

            //Game:
            Container.BindInterfacesAndSelfTo<GameStartController>()
                .AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverController>()
                .AsSingle();
            Container.BindInterfacesAndSelfTo<DifficultyController>()
                .AsSingle();
            Container.BindInterfacesAndSelfTo<ScoreController>()
                .AsSingle();
        }
    }
}