using SampleGame.Gameplay;

namespace Game.App
{
    public sealed class HealthSerializer : GenericSerializer<Health, HealthData>
    {
        private readonly Health _health;

        public HealthSerializer(Health health)
        {
            _health = health;
        }

        protected override HealthData Serialize(Health service)
        {
            return new HealthData{value = service.Current};
        }

        protected override void Deserialize(Health service, HealthData data)
        {
            _health.Current = data.value;
        }
    }
}