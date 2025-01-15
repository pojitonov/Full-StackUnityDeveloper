using UnityEngine;

namespace Game.Scripts.Components
{
    // TODO: Не должен зависеть от MoveComponent и быть универсальным

    public class FlipComponent : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        
        private MoveComponent _moveComponent;

        private void Awake()
        {
            _moveComponent = GetComponent<MoveComponent>();
        }

        public void Update()
        {
            var direction = _moveComponent.Direction;
            
            if (direction.x > 0)
            {
                _transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (direction.x < 0)
            {
                _transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}