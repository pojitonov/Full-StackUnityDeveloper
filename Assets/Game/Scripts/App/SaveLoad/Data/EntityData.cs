using System;
using Modules.Entities;

namespace Game.App
{
    [Serializable]
    public struct EntityData
    {
        public int id;
        public string name;
        public EntityType entityType;
    }
}