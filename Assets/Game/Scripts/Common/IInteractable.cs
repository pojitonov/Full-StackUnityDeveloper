using UnityEngine;

namespace Game.Scripts
{
    public interface IInteractable
    {
        void Push(Vector2 direction, float force);
    }
}