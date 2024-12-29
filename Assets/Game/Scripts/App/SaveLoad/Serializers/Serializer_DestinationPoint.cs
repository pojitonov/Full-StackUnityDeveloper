using System;
using SampleGame.Common;
using SampleGame.Gameplay;

namespace Game.App
{
    [Serializable]
    public struct DestinationPointData
    {
        public SerializedVector3 value;
    }

    public sealed class Serializer_DestinationPoint : Serializer<DestinationPoint, DestinationPointData>
    {
        protected override DestinationPointData Serialize(DestinationPoint component)
        {
            return new DestinationPointData { value = component.Value };
        }

        protected override void Deserialize(DestinationPoint component, DestinationPointData data)
        {
            component.Value = data.value;
        }
    }
}