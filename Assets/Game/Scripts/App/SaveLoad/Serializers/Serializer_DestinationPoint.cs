using SampleGame.Gameplay;

namespace Game.App
{
    public sealed class Serializer_DestinationPoint : Serializer<DestinationPoint, Data_DestinationPoint>
    {
        protected override Data_DestinationPoint Serialize(DestinationPoint component)
        {
            return new Data_DestinationPoint { value = component.Value };
        }

        protected override void Deserialize(DestinationPoint component, Data_DestinationPoint data)
        {
            component.Value = data.value;
        }
    }
}