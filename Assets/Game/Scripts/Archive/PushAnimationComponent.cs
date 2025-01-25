// using UnityEngine;
//
// namespace Game.Scripts.Components
// {
//     public class PushAnimationComponent : MonoBehaviour
//     {
//         [SerializeField] private ParticleSystem _particleSource;
//         
//         private ForceActionComponent _forceActionComponent;
//
//         private void Awake()
//         {
//             _forceActionComponent = GetComponentInParent<ForceActionComponent>();
//         }
//
//         private void OnEnable()
//         {
//             _forceActionComponent.OnForceApplied += Play;
//         }
//
//         private void OnDisable()
//         {
//             _forceActionComponent.OnForceApplied -= Play;
//         }
//
//         private void Play()
//         {
//             _particleSource.Stop();
//             _particleSource.Play();
//         }
//     }
// }