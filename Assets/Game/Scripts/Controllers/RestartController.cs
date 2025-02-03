using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public sealed class RestartController : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}