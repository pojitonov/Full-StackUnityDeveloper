using System;
using SampleGame.Common;
using SampleGame.Gameplay;

namespace Game.App
{
    public sealed class ResourceBagSerializer : ComponentSerializer<ResourceBag, ResourceBagData>
    {
        protected override ResourceBagData Serialize(ResourceBag component)
        {
            return new ResourceBagData
            {
                type = component.Type.ToString(),
                current = component.Current
            };
        }

        protected override void Deserialize(ResourceBag component, ResourceBagData resourceBagData)
        {
            Enum.TryParse<ResourceType>(resourceBagData.type, out var value);
            component.Type = value;
            component.Current = resourceBagData.current;
        }
    }
}