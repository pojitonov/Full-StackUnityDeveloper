using UnityEngine;

namespace Game
{
    public sealed class ForceController : MonoBehaviour
    {
        [SerializeField] private Character _character;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
               _character.Toss();
            }

            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
            {
                _character.Push();
            }
        }
    }
}