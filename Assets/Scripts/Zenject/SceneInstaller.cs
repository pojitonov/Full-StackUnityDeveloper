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
            _InputInstaller.Install(Container);
            _GameInstaller.Install(Container, _maxLevels);
            _CoinInstaller.Install(Container, _coinPrefab, _worldTransform);
            _SnakeInstaller.Install(Container, _snake);
        }
    }
}