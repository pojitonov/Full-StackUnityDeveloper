// using UnityEngine;
//
// namespace Game
// {
//     public class TossSoundComponent : MonoBehaviour
//     {
//         [SerializeField] private AudioSource _audioSource;
//         [SerializeField] private AudioClip _audioClip;
//         [SerializeField] private PushComponent _component;
//         
//         private void OnEnable()
//         {
//             _component.OnTossed += PlayAudio;
//         }
//
//         private void OnDisable()
//         {
//             _component.OnTossed -= PlayAudio;
//         }
//
//         private void PlayAudio()
//         {
//             Play(_audioClip);
//         }
//
//         private void Play(AudioClip audioClip)
//         {
//             _audioSource.PlayOneShot(audioClip);
//         }
//     }
// }