// using UnityEngine;
//
// namespace Game.Scripts
// {
//     public class DeathHandlerComponent : MonoBehaviour
//     {
//         [SerializeField]
//         private HealthComponent _healthComponent;
//
//         [SerializeField]
//         private Countdown _countdown;
//
//         private bool _isCountdownStarted;
//
//         private void Awake()
//         {
//             if (_healthComponent != null)
//             {
//                 _healthComponent.OnHealthDepleted += StartCountdown;
//             }
//
//             _countdown.OnTimeIsUp += Destroy;
//         }
//
//         private void OnDestroy()
//         {
//             {
//                 _healthComponent.OnHealthDepleted -= StartCountdown;
//             }
//
//             _countdown.OnTimeIsUp -= Destroy;
//         }
//
//         private void Update()
//         {
//             if (_isCountdownStarted)
//             {
//                 _countdown.Tick(Time.deltaTime);
//             }
//         }
//
//         public void Destroy()
//         {
//             gameObject.SetActive(false);
//         }
//
//         private void StartCountdown()
//         {
//             if (!_isCountdownStarted)
//             {
//                 _isCountdownStarted = true;
//                 _countdown.Reset();
//             }
//         }
//     }
// }