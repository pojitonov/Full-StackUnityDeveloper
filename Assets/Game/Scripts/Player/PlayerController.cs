using UnityEngine;

namespace ShootEmUp
{
    public sealed class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Player player;

        private void Awake()
        {
            HandleGameOver();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                player.SetFiring(true);
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                player.SetMoveDirection(-1);
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                player.SetMoveDirection(1);
            else
                player.SetMoveDirection(0);
        }

        private void HandleGameOver()
        {
            player.OnHealthEmpty += _ => Time.timeScale = 0;
        }
    }
}