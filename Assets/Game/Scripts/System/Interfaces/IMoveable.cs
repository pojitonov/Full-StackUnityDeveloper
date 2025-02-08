using UnityEngine;

namespace Game
{
    public interface IMoveable
    {
        Vector3 Position { get; }
        Vector2 Direction { set; }
    }
}