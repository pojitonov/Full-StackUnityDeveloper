using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class CharacterFireController : MonoBehaviour
    {
        [SerializeField]
        private SceneEntity _character;

        private void Update()
        {
            HandleKeyboard();
        }

        private void HandleKeyboard()
        {
            if (Input.GetKey(KeyCode.E))
                _character.GetWeapon().FireBullet();
        }
    }
}