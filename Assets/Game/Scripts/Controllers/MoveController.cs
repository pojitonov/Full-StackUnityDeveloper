using Game.Scripts.Components;
using Game.Scripts.Objects;
using UnityEngine;

namespace Game.Scripts.Controllers
{
    public sealed class MoveController : MonoBehaviour
    {
        [SerializeField] private Character _character;
        
        private MoveComponent _moveComponent;

        private void Awake()
        {
            _moveComponent = _character.GetComponent<MoveComponent>();
        }

        private void Update()
        {
            var direction = Vector2.zero;

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                direction = Vector2.left;
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                direction = Vector2.right;
            }

            _moveComponent.Direction = direction;
        }
    }
}