using Game.UI.Planet;
using Modules.UI;
using UnityEngine;
using Zenject;

namespace Game.UI
{
    public sealed class ModulesInstaller : Installer<PlanetView[], GameObject, ModulesInstaller>
    {
        [Inject]
        private PlanetView[] planetsViews;

        [Inject]
        private GameObject coinEndPosition;

        public override void InstallBindings()
        {
            Container
                .Bind<CounterAnimation>()
                .FromComponentInHierarchy()
                .AsCached()
                .NonLazy();
            
            Container.Bind<GameObject>()
                .WithId("CoinEndPosition")
                .FromInstance(coinEndPosition)
                .AsSingle();

            foreach (PlanetView view in planetsViews)
            {
                Container
                    .Bind<FlyingAnimation>()
                    .FromComponentInNewPrefab(view)
                    .AsCached()
                    .WithArguments(coinEndPosition)
                    .NonLazy();
            }
        }
    }
}