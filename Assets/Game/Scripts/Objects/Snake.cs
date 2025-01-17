using Game.Scripts.Components;
using UnityEngine;

namespace Game.Scripts.Objects
{
    public sealed class Snake : MonoBehaviour
    {
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private FlipComponent _flipComponent;
        
        private void Update()
        {
            _flipComponent.Direction = _moveComponent.Direction;
        }
    }
}