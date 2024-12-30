using Modules.Entities;
using SampleGame.Gameplay;

namespace Game.App
{
    public sealed class TargetObjectSerializer : ComponentSerializer<TargetObject, EntityWorld, TargetObjectData>
    {
        protected override TargetObjectData Serialize(TargetObject component, EntityWorld service)
        {
            return new TargetObjectData
            {
                value = component.Value?.Id ?? -1
            };
        }

        protected override void Deserialize(TargetObject component, EntityWorld service, TargetObjectData targetObjectData)
        {
            service.TryGet(targetObjectData.value, out var value);
            component.Value = value;
        }
    }
}