using System;
using SampleGame.Common;
using SampleGame.Gameplay;

namespace Game.App
{
    public sealed class TeamSerializer : ComponentSerializer<Team, TeamData>
    {
        protected override TeamData Serialize(Team component)
        {
            return new TeamData { value = component.Type.ToString() };
        }

        protected override void Deserialize(Team component, TeamData teamData)
        {
            Enum.TryParse<TeamType>(teamData.value, out var value);
            component.Type = value;
        }
    }
}