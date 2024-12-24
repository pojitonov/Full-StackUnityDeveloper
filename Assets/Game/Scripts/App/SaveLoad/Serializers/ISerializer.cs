using System.Collections.Generic;

namespace Game.App
{
    public interface ISerializer
    {
        void Serialize(Dictionary<string, object> gameState);
        void Dederialize(Dictionary<string, object> gameState);
    }
}