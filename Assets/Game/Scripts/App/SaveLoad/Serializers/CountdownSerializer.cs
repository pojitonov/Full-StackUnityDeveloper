using System;
using SampleGame.Gameplay;

namespace Game.App
{
    [Serializable]
    public struct CountdownData
    {
        public float value;
    }
    
    public sealed class CountdownSerializer : GenericSerializer<Countdown, CountdownData>
    {
        protected override CountdownData Serialize(Countdown component)
        {
            return new CountdownData { value = component.Current };
        }

        protected override void Deserialize(Countdown component, CountdownData data)
        {
            component.Current = data.value;
        }
    }
}