using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay
{
    public class CharacterFireController : MonoBehaviour
    {
        [SerializeField] private SceneEntity _character;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _character.GetFireAction().Invoke();
            }
        }
    }
}