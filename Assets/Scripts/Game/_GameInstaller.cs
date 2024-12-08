using Modules;
using Zenject;

namespace SnakeGame
{
    public class _GameInstaller : Installer<int, _GameInstaller>
    {
        [Inject]
        private int _maxLevels;

        public override void InstallBindings()
        {
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

            Container.BindInterfacesAndSelfTo<StartGame>()
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