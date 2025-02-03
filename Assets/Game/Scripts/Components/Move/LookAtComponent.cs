using UnityEngine;

namespace Game
{
    public class LookAtComponent : MonoBehaviour
    {
        public Vector2 Direction { get; private set; } = Vector2.right;
        
        public void SetDirection(Vector2 direction)
        {
            if (direction == Vector2.right || direction == Vector2.left) 
                Direction = direction;
        }
    }
}