using UnityEngine;

namespace Game.Scripts
{
    public interface ITossable
    {
        void Toss(Vector2 direction, float force);
    }
}