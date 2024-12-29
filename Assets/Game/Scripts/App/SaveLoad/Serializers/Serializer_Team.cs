using System;
using SampleGame.Common;
using SampleGame.Gameplay;

namespace Game.App
{
    public sealed class Serializer_Team : Serializer<Team, Data_Team>
    {
        protected override Data_Team Serialize(Team component)
        {
            return new Data_Team { value = component.Type.ToString() };
        }

        protected override void Deserialize(Team component, Data_Team data)
        {
            Enum.TryParse<TeamType>(data.value, out var value);
            component.Type = value;
        }
    }
}