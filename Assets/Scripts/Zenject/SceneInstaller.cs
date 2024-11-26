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
 
        const int maxDifficulty = 10;

        public override void InstallBindings()
        {
            Container.Bind<Coin>().FromInstance(_coinPrefab).AsCached();
            Container.Bind<ISnake>().FromInstance(_snake).AsSingle();

            Container.BindInterfacesAndSelfTo<Difficulty>().AsSingle().WithArguments(maxDifficulty);
            Container.Bind<IScore>().To<Score>().AsSingle();
            Container.Bind<IGameUI>().To<GameUI>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IWorldBounds>().To<WorldBounds>().FromComponentInHierarchy().AsSingle();

            Container.BindInterfacesTo<PlayerController>().AsSingle();
            Container.BindInterfacesAndSelfTo<CoinManager>().AsSingle();
            Container.BindInterfacesTo<GameManager>().AsSingle();
        }
    }
}