// using System;
// using Modules;
// using Zenject;
//
// namespace SnakeGame
// {
//     public class GameOverController : IInitializable, IDisposable
//     {
//         private readonly ISnake _snake;
//         private readonly GameCycle _gameCycle;
//
//         public GameOverController(GameCycle gameCycle, ISnake snake)
//         {
//             _gameCycle = gameCycle;
//             _snake = snake;
//         }
//
//         public void Initialize()
//         {
//             _gameCycle.OnFinished += HandleGameOver;
//         }
//         
//         public void Dispose()
//         {
//             _gameCycle.OnFinished += HandleGameOver;
//         }
//
//         private void HandleGameOver(bool _)
//         {
//             _snake.SetActive(false);
//         }
//     }
// }