using System;
using SampleGame.Common;
using SampleGame.Gameplay;

namespace Game.App
{
    [Serializable]
    public struct TeamData
    {
        public string value;
    }

    public sealed class Serializer_Team : Serializer<Team, TeamData>
    {
        protected override TeamData Serialize(Team component)
        {
            return new TeamData { value = component.Type.ToString() };
        }

        protected override void Deserialize(Team component, TeamData data)
        {
            Enum.TryParse<TeamType>(data.value, out var value);
            component.Type = value;
        }
    }
}