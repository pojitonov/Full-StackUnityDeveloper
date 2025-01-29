using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class CharacterMoveController : MonoBehaviour
    {
        [SerializeField] private SceneEntity _character;

        private void Update()
        {
            var direction = InputUseCase.GetMoveDirection();
            _character.GetMoveDirection().Value = direction;
        }
    }
}