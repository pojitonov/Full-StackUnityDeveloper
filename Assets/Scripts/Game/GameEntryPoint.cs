using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public class GameEntryPoint : MonoBehaviour
    {
        private GameCycle _gameCycle;

        [Inject]
        public void Construct(GameCycle gameCycle)
        {
            _gameCycle = gameCycle;
        }
        
        public void Start()
        {
            _gameCycle.Start();
        }
    }
}