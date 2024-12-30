using Game.App;
using UnityEngine;

namespace SampleGame.Gameplay
{
    //Can be extended
    public sealed class DestinationPoint : MonoBehaviour, ISerializable<DestinationPointSerializer>
    {
        ///Variable
        [field: SerializeField]
        public Vector3 Value { get; set; }
    }
}