using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public class _CoinInstaller : Installer<Coin, Transform, _CoinInstaller>
    {
        [Inject]
        private Coin _coinPrefab;

        [Inject]
        private Transform _worldTransform;

        public override void InstallBindings()
        {
            Container.Bind<Coin>()
                .FromInstance(_coinPrefab)
                .AsCached();
            
            Container.BindFactory<Coin, Factory>()
                .FromComponentInNewPrefab(_coinPrefab)
                .WithGameObjectName("Coin")
                .UnderTransform(_worldTransform)
                .AsSingle();

            Container.Bind<IWorldBounds>()
                .To<WorldBounds>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<CoinSpawner>()
                .AsSingle();
        }
    }
}