using UnityEngine;

namespace Game.Scripts
{
    public interface IInteractable
    {
        // void Toss(Vector2 direction, float force);
        void Push(Vector2 direction, float force);
    }
}