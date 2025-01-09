using UnityEngine;

namespace Game.Scripts
{
    public class FlipComponent : MonoBehaviour
    {
        [SerializeField]
        private Transform _transform;

        private Character _character;

        private void Awake()
        {
            _character = GetComponent<Character>();
        }

        public void Update()
        {
            var direction = _character.MoveDirection;
            
            if (direction == Vector2.right)
            {
                _transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (direction == Vector2.left)
            {
                _transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}