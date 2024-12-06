using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField]
        private Coin _coinPrefab;

        [SerializeField]
        private Snake _snake;

        [SerializeField]
        private int _maxDifficulty = 9;

        public override void InstallBindings()
        {
            GameInstaller.Install(Container, _maxDifficulty);
            InputInstaller.Install(Container);

            
              Container.Bind<Coin>()
                .FromInstance(_coinPrefab)
                .AsCached();
            Container.Bind<ISnake>()
                .FromInstance(_snake)
                .AsSingle();
            
            Container.Bind<IWorldBounds>()
                .To<WorldBounds>()
                .FromComponentInHierarchy()
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<CoinManager>()
                .AsSingle();
            Container.BindInterfacesAndSelfTo<SnakeManager>()
                .AsSingle();
        }
    }
}