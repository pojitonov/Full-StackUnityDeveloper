using UnityEngine;

namespace Game.Scripts
{
    public class PlayPushSound : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private PushComponent _pushComponent;

        private void OnEnable()
        {
            _pushComponent.OnPushed += Play;
        }

        private void OnDisable()
        {
            _pushComponent.OnPushed -= Play;
        }

        private void Play()
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}