// using UnityEngine;
// using UnityEngine.Serialization;
//
// namespace Game.Scripts.Components
// {
//     public class PushSoundComponent : MonoBehaviour
//     {
//         [SerializeField] private AudioSource _audioSource;
//         [SerializeField] private AudioClip _audioClip;
//         [FormerlySerializedAs("_pushComponent")]
//         [SerializeField] private ForceActionComponent _forceActionComponent;
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
//             _audioSource.PlayOneShot(_audioClip);
//         }
//     }
// }