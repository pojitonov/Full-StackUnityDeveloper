using System;
using System.Collections.Generic;
using SampleGame.Common;

namespace Game.App
{
    [Serializable]
    public class EntityData
    {
        public int id;
        public string entityName;
        public string entityType;
        public SerializedVector3 position;
        public SerializedVector3 rotation;
        public Dictionary<string, string> components;
    }
}