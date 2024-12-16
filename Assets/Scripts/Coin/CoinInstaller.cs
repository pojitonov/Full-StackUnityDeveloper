using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public class CoinInstaller : Installer<Coin, Transform, int, CoinInstaller>
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
            
            Container.Bind<IWorldBounds>()
                .To<WorldBounds>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<CoinManager>()
                .AsSingle();
            
            Container.BindMemoryPool<Coin, CoinsPool>()
                .WithInitialSize(_maxLevels)
                .FromComponentInNewPrefab(_coinPrefab)
                .WithGameObjectName("Coin")
                .UnderTransform(_worldTransform)
                .AsSingle();
        }
    }
}