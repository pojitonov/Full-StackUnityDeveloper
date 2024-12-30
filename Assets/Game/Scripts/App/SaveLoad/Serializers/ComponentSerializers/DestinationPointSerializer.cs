using SampleGame.Gameplay;

namespace Game.App
{
    public sealed class DestinationPointSerializer : ComponentSerializer<DestinationPoint, DestinationPointData>
    {
        protected override DestinationPointData Serialize(DestinationPoint component)
        {
            return new DestinationPointData
            {
                value = component.Value
            };
        }

        protected override void Deserialize(DestinationPoint component, DestinationPointData destinationPointData)
        {
            component.Value = destinationPointData.value;
        }
    }
}