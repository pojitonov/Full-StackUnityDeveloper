using UnityEngine;

namespace Game
{
    public class JumpController : MonoBehaviour
    {
        [SerializeField] private GameObject _character;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                _character.GetComponent<IJumpComponent>().Jump();
            }
        }
    }
}