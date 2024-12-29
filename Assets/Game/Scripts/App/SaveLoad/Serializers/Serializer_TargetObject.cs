using System;
using Modules.Entities;
using SampleGame.Gameplay;

namespace Game.App
{
    [Serializable]
    public struct TargetObjectData
    {
        public int value;
    }
    
    public sealed class Serializer_TargetObject : Serializer<TargetObject, EntityWorld, TargetObjectData>
    {
        protected override TargetObjectData Serialize(TargetObject component, EntityWorld service)
        {
            return new TargetObjectData { value = component.Value.Id };
        }

        protected override void Deserialize(TargetObject component, EntityWorld service, TargetObjectData data)
        {
            service.TryGet(data.value, out var entity);
            component.Value = entity;
        }
    }
}