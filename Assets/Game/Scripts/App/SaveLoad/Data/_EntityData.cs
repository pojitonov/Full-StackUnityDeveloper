using System;
using Modules.Entities;

namespace Game.App
{
    [Serializable]
    public struct _EntityData
    {
        public int id;
        public string name;
        public EntityType entityType;
    }
}