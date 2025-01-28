using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class CharacterFireController : MonoBehaviour
    {
        [SerializeField] private SceneEntity _character;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _character.GetFireAction().Invoke();
            }
        }
    }
}