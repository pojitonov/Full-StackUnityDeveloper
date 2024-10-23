using UnityEngine;

namespace ShootEmUp
{
    public sealed class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Player player;

        [SerializeField]
        private BulletManager bulletManager;

        private bool isFiring;
        private int moveDirection;
        private IPlayerMovement playerMovement;
        private IPlayerShooting playerShooting;

        private void Awake()
        {
            playerMovement = new PlayerMovement(player);
            playerShooting = new PlayerShooting(player, bulletManager);
            player.OnHealthEmpty += _ => Time.timeScale = 0;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                isFiring = true;
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                moveDirection = -1;
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                moveDirection = 1;
            else
                moveDirection = 0;
        }

        private void FixedUpdate()
        {
            playerMovement.Move(moveDirection);

            if (isFiring)
            {
                playerShooting.Shoot();
                isFiring = false;
            }
        }
    }
}