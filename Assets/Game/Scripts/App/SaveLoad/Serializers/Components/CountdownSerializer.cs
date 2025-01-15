using SampleGame.Gameplay;

namespace Game.App
{
    public sealed class CountdownSerializer : ComponentSerializer<Countdown, CountdownData>
    {
        protected override CountdownData Serialize(Countdown component)
        {
            return new CountdownData
            {
                value = component.Current
            };
        }

        protected override void Deserialize(Countdown component, CountdownData countdownData)
        {
            component.Current = countdownData.value;
        }
    }
}