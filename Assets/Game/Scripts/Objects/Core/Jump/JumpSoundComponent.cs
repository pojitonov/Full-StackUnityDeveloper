using UnityEngine;

namespace Game
{
    public class JumpSoundComponent : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private JumpComponent _component;

        private void OnEnable()
        {
            _component.OnJumped += Play;
        }

        private void OnDisable()
        {
            _component.OnJumped -= Play;
        }

        private void Play()
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}