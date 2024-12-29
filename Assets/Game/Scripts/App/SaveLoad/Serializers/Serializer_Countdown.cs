using SampleGame.Gameplay;

namespace Game.App
{
    public sealed class Serializer_Countdown : Serializer<Countdown, Data_Countdown>
    {
        protected override Data_Countdown Serialize(Countdown component)
        {
            return new Data_Countdown { value = component.Current };
        }

        protected override void Deserialize(Countdown component, Data_Countdown data)
        {
            component.Current = data.value;
        }
    }
}