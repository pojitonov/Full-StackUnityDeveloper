using Modules.Entities;
using SampleGame.Gameplay;

namespace Game.App
{
    public sealed class Serializer_TargetObject : Serializer<TargetObject, EntityWorld, Data_TargetObject>
    {
        protected override Data_TargetObject Serialize(TargetObject component, EntityWorld service)
        {
            return new Data_TargetObject { value = component.Value.Id };
        }

        protected override void Deserialize(TargetObject component, EntityWorld service, Data_TargetObject data)
        {
            service.TryGet(data.value, out var value);
            component.Value = value;
        }
    }
}