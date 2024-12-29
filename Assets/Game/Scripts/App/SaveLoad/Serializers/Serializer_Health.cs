using SampleGame.Gameplay;

namespace Game.App
{
    public sealed class Serializer_Health : Serializer<Health, Data_Health>
    {
        protected override Data_Health Serialize(Health component)
        {
            return new Data_Health { value = component.Current };
        }

        protected override void Deserialize(Health component, Data_Health data)
        {
            component.Current = data.value;
        }
    }
}