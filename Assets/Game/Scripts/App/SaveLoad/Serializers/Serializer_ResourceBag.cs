using SampleGame.Gameplay;

namespace Game.App
{
    public sealed class Serializer_ResourceBag : Serializer<ResourceBag, Data_ResourceType>
    {
        protected override Data_ResourceType Serialize(ResourceBag component)
        {
            return new Data_ResourceType
            {
                type = component.Type,
                current = component.Current
            };
        }

        protected override void Deserialize(ResourceBag component, Data_ResourceType data)
        {
            component.Type = data.type;
            component.Current = data.current;
        }
    }
}