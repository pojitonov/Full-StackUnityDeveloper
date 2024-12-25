using SampleGame.Gameplay;

namespace Game.App
{
    public sealed class CountdownSerializer : GenericSerializer<Countdown, CountdownData>
    {
        private readonly Countdown _countdown;

        public CountdownSerializer(Countdown countdown)
        {
            _countdown = countdown;
        }

        protected override CountdownData Serialize(Countdown service)
        {
            return new CountdownData{value = service.Current};
        }

        protected override void Deserialize(Countdown service, CountdownData data)
        {
            _countdown.Current = data.value;
        }
    }
}