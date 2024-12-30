using Game.App;
using Modules.Entities;
using UnityEngine;

namespace SampleGame.Gameplay
{
    //Can be extended
    public sealed class TargetObject : MonoBehaviour, ISerializable<TargetObjectSerializer>
    {
        ///Variable
        [field: SerializeField]
        public Entity Value { get; set; }
    }
}