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

            Container.Bind<IWorldBounds>()
                .To<WorldBounds>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<CoinFactory>()
                .AsSingle();
            
            Container.Bind<CoinCollector>()
                .AsSingle();
        }
    }
}