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

        public override void InstallBindings()
        {
            InputInstaller.Install(Container);
            GameInstaller.Install(Container, _maxLevels);
            CoinInstaller.Install(Container, _coinPrefab);
            SnakeInstaller.Install(Container, _snake);
        }
    }
}