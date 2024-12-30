using System;
using System.Collections.Generic;

namespace Game.App
{
    public interface IComponentSerializer
    {
        public Type Type { get; }

        void Serialize(ISerializable component, IDictionary<string, string> gameState);
        void Deserialize(ISerializable component, IDictionary<string, string> gameState);
    }
}