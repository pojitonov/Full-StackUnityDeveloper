using UnityEngine;

namespace Game.Scripts
{
    public sealed class PushController : MonoBehaviour
    {
        [SerializeField]
        private Character _character;

        private void Update()
        {
            var lokAtDirection = _character._lookAtComponent.FacingDirection;

            if (Input.GetKeyDown(KeyCode.W))
            {
                _character._pushComponent.Push(lokAtDirection, Vector2.up);
            }

            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
            {
                if (lokAtDirection == Vector2.left)
                    _character._pushComponent.Push(lokAtDirection, Vector2.left)
                ;
                if (lokAtDirection == Vector2.right)
                    _character._pushComponent.Push(lokAtDirection, Vector2.right);
            }
        }
    }
}