using UnityEngine;

namespace Game.Scripts.Interfaces
{
    public interface IMoveable
    {
        Vector3 Position { get; }
        Vector2 Direction { get; set; }
    }
}