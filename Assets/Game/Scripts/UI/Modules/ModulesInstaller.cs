using Modules.UI;
using UnityEngine;
using Zenject;

namespace Game.UI
{
    public sealed class ModulesInstaller : Installer<GameObject, ModulesInstaller>
    {
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
        }
    }
}