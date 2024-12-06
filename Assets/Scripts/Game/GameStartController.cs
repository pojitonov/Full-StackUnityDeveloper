using Zenject;

namespace SnakeGame
{
    public class GameStartController : IInitializable
    {
        private readonly ScoreController _scoreController;
        private readonly DifficultyController _difficultyController;

        public GameStartController(ScoreController scoreController, DifficultyController difficultyController)
        {
            _scoreController = scoreController;
            _difficultyController = difficultyController;
        }

        public void Initialize()
        {
            _scoreController.Initialize();
            _difficultyController.Initialize();
        }
    }
}