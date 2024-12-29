using System;
using SampleGame.Common;
using SampleGame.Gameplay;

namespace Game.App
{
    [Serializable]
    public struct ResourceTypeData
    {
        public ResourceType type;
        public int current;
    }
    
    public sealed class ResourceBagSerializer : GenericSerializer<ResourceBag, ResourceTypeData>
    {
        protected override ResourceTypeData Serialize(ResourceBag component)
        {
            return new ResourceTypeData
            {
                type = component.Type,
                current = component.Current
            };
        }

        protected override void Deserialize(ResourceBag component, ResourceTypeData data)
        {
            component.Type = data.type;
            component.Current = data.current;
        }
    }
}