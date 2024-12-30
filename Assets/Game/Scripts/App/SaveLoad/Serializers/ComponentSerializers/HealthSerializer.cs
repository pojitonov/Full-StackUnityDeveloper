using SampleGame.Gameplay;

namespace Game.App
{
    public sealed class HealthSerializer : ComponentSerializer<Health, HealthData>
    {
        protected override HealthData Serialize(Health component)
        {
            return new HealthData
            {
                value = component.Current
            };
        }

        protected override void Deserialize(Health component, HealthData healthData)
        {
            component.Current = healthData.value;
        }
    }
}