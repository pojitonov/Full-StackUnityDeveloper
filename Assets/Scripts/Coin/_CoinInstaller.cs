using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public class _CoinInstaller : Installer<Coin, Transform, int, _CoinInstaller>
    {
        [Inject]
        private Coin _coinPrefab;

        [Inject]
        private Transform _worldTransform;

        [Inject]
        private int _maxLevels;

        public override void InstallBindings()
        {
            Container.Bind<Coin>()
                .FromInstance(_coinPrefab)
                .AsCached();

            Container.BindMemoryPool<Coin, CoinsPool>()
                .WithInitialSize(_maxLevels)
                .FromComponentInNewPrefab(_coinPrefab)
                .WithGameObjectName("Coin")
                .UnderTransform(_worldTransform)
                .AsSingle();

            Container.Bind<IWorldBounds>()
                .To<WorldBounds>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.Bind<CoinCollector>()
                .AsSingle();

            Container.Bind<CoinCollisionController>()
                .AsSingle();

            Container.Bind<CoinManager>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<CoinSpawner>()
                .AsSingle();
        }
    }
}