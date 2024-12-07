using Modules;
using Zenject;

namespace SnakeGame
{
    public class CoinInstaller : Installer<Coin, CoinInstaller>
    {
        [Inject]
        private Coin _coinPrefab;

        public override void InstallBindings()
        {
            Container.Bind<Coin>()
                .FromInstance(_coinPrefab)
                .AsCached();
            
            Container.BindFactory<Coin, CoinFactory>()
                .FromComponentInNewPrefab(_coinPrefab)
                .AsSingle();

            Container.Bind<IWorldBounds>()
                .To<WorldBounds>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<CoinSpawner>()
                .AsSingle();
            
            Container.Bind<CoinCollector>()
                .AsSingle();
        }
    }
}