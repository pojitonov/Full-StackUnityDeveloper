using UnityEngine;

namespace Game.Scripts
{
    public sealed class PushController : MonoBehaviour
    {
        [SerializeField]
        private Character _character;

        private void Update()
        {
            var lokAtDirection = _character._lookAtComponent.LookAtDirection;

            if (Input.GetKeyDown(KeyCode.W))
            {
                _character._tossComponent.Toss();
            }

            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
            {
                if (lokAtDirection == Vector2.left)
                    _character._pushComponent.Push(Vector2.left)
                ;
                if (lokAtDirection == Vector2.right)
                    _character._pushComponent.Push(Vector2.right);
            }
        }
    }
}