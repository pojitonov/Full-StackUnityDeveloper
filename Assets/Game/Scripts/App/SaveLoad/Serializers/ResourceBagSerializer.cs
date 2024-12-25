using SampleGame.Gameplay;

namespace Game.App
{
    public sealed class ResourceBagSerializer : GenericSerializer<ResourceBag, ResourceTypeData>
    {
        private readonly ResourceBag _resourceBag;

        public ResourceBagSerializer(ResourceBag resourceBag)
        {
            _resourceBag = resourceBag;
        }

        protected override ResourceTypeData Serialize(ResourceBag service)
        {
            return new ResourceTypeData
            {
                type = service.Type,
                current = service.Current
            };
        }

        protected override void Deserialize(ResourceBag service, ResourceTypeData data)
        {
            _resourceBag.Type = data.type;
            _resourceBag.Current = data.current;
        }
    }
}