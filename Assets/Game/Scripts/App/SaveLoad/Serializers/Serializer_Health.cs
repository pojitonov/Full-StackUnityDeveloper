using System;
using SampleGame.Gameplay;

namespace Game.App
{
    [Serializable]
    public struct HealthData
    {
        public int value;
    }

    public sealed class Serializer_Health : Serializer<Health, HealthData>
    {
        protected override HealthData Serialize(Health component)
        {
            return new HealthData { value = component.Current };
        }

        protected override void Deserialize(Health component, HealthData data)
        {
            component.Current = data.value;
        }
    }
}