// using UnityEngine;
//
// namespace Game
// {
//     public class TossAnimationComponent : MonoBehaviour
//     {
//         [SerializeField] private ParticleSystem _particleSource;
//         [SerializeField] private PushComponent _component;
//
//         private void OnEnable()
//         {
//             _component.OnTossed += PlayAnimation;
//         }
//
//         private void OnDisable()
//         {
//             _component.OnTossed -= PlayAnimation;
//         }
//
//         private void PlayAnimation()
//         {
//             Play(_particleSource);
//         }
//
//         private void Play(ParticleSystem particleSystem)
//         {
//             particleSystem.Stop();
//             particleSystem.Play();
//         }
//     }
// }