using System.Collections.Generic;
using SampleGame.Gameplay;

namespace Game.App
{
    public sealed class CountdownSerializer : ISerializer
    {
        private readonly Countdown _countdown;

        public CountdownSerializer(Countdown countdown)
        {
            _countdown = countdown;
        }

        public void Serialize(IDictionary<string, string> gameState)
        {
            gameState["countdown"] = _countdown.Current.ToString();
        }

        public void Deserialize(IDictionary<string, string> gameState)
        {
            if (gameState.TryGetValue("countdown", out string value))
            {
                int countdown = int.Parse(value);
                _countdown.Current = countdown;
            }
        }
    }
}