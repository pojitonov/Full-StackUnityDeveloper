using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField]
        private Snake _snake;

        [SerializeField]
        private Coin _coinPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<ISnake>().FromInstance(_snake).AsSingle();
            Container.BindInterfacesTo<PlayerController>().AsCached();

            Container.Bind<WorldBounds>().FromComponentInHierarchy().AsSingle();
            Container.Bind<Coin>().FromInstance(_coinPrefab).AsSingle();
            Container.BindInterfacesTo<CoinSpawner>().AsSingle();
        }
    }
}