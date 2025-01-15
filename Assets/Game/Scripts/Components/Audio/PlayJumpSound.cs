using Game.Scripts.Components;
using UnityEngine;

namespace Game.Scripts.Components
{
    public class PlayJumpSound : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private JumpComponent _jumpComponent;

        private void OnEnable()
        {
            _jumpComponent.OnJumped += Play;
        }

        private void OnDisable()
        {
            _jumpComponent.OnJumped -= Play;
        }

        private void Play()
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}