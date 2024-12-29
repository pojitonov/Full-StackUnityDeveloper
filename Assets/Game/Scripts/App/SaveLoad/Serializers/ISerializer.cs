using System.Collections.Generic;

namespace Game.App
{
    public interface ISerializer
    {
        void Serialize(IDictionary<string, string> gameState);
        void Deserialize(IDictionary<string, string> gameState);
    }
}