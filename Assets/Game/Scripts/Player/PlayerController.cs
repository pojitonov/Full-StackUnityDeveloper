using UnityEngine;

namespace ShootEmUp
{
    public sealed class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private BulletConfig bulletConfig;
        
        private Ship player;

        private void Awake()
        {
            player = GetComponent<Ship>();
            HandleGameOver();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                player.Fire(Vector3.up , bulletConfig);
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                player.SetDirection(-1);
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                player.SetDirection(1);
            else
                player.SetDirection(0);
        }

        private void HandleGameOver()
        {
            player.OnHealthEmpty += _ => Time.timeScale = 0;
        }
    }
}