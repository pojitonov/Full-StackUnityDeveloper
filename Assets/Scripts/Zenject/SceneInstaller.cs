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
            Container.Bind<Coin>().FromInstance(_coinPrefab).AsCached();
            
            Container.Bind<IWorldBounds>().To<WorldBounds>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IGameUI>().To<GameUI>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IScore>().To<Score>().AsSingle();
            
            Container.BindInterfacesTo<PlayerController>().AsSingle();
            Container.BindInterfacesAndSelfTo<CoinController>().AsSingle();
            Container.BindInterfacesTo<GameCycle>().AsSingle();
        }
    }
}