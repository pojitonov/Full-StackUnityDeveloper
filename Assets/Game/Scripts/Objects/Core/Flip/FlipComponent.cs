using UnityEngine;

namespace Game
{
    public class FlipComponent : MonoBehaviour
    {
        public Vector2 Direction { get; set; }

        [SerializeField] private Transform _transform;

        public void Update()
        {
            if (Direction.x > 0)
            {
                _transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (Direction.x < 0)
            {
                _transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}