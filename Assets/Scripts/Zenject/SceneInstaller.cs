using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField]
        private int _maxLevels = 9;

        [SerializeField]
        private Coin _coinPrefab;

        [SerializeField]
        private Snake _snake;
        
        [SerializeField]
        private Transform _worldTransform;

        public override void InstallBindings()
        {
            GameInstaller.Install(Container, _maxLevels);
            InputInstaller.Install(Container);
            SnakeInstaller.Install(Container, _snake);
            CoinInstaller.Install(Container, _coinPrefab, _worldTransform, _maxLevels);
            UIInstaller.Install(Container);
        }
    }
}