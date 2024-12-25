using SampleGame.Gameplay;

namespace Game.App
{
    public sealed class DestinationPointSerializer : GenericSerializer<DestinationPoint, DestinationPointData>
    {
        private readonly DestinationPoint _destinationPoint;

        public DestinationPointSerializer(DestinationPoint destinationPoint)
        {
            _destinationPoint = destinationPoint;
        }

        protected override DestinationPointData Serialize(DestinationPoint service)
        {
            return new DestinationPointData{value = service.Value};
        }

        protected override void Deserialize(DestinationPoint service, DestinationPointData data)
        {
            _destinationPoint.Value = data.value;
        }
    }
}