using Modules;

namespace SnakeGame
{
    public class ScoreController
    {
        private readonly IScore _score;

        public ScoreController(IScore score)
        {
            _score = score;
        }

        public void AddScore(int points)
        {
            _score.Add(points);
        }
    }
}