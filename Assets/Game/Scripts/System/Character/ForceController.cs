using UnityEngine;

namespace Game
{
    public sealed class ForceController : MonoBehaviour
    {
        [SerializeField] private GameObject _character;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
               _character.GetComponent<ITossComponent>().Toss();
            }

            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
            {
                _character.GetComponent<IPushComponent>().Push();
            }
        }
    }
}