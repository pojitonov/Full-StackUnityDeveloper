using System.Collections.Generic;

namespace Game.App
{
    public interface IComponentSerializer
    {
        void Serialize(IDictionary<string, string> gameState);
        void Deserialize(IDictionary<string, string> gameState);
    }
}