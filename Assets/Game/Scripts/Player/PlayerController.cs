using UnityEngine;

namespace ShootEmUp
{
    public sealed class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private BulletConfig bulletConfig;
        
        private Ship ship;

        private void Awake()
        {
            ship = GetComponent<Ship>();
            HandleGameOver();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                ship.Fire(Vector3.up , bulletConfig);
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                ship.SetDirection(-1);
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                ship.SetDirection(1);
            else
                ship.SetDirection(0);
        }

        private void HandleGameOver()
        {
            ship.OnHealthEmpty += _ => Time.timeScale = 0;
        }
    }
}