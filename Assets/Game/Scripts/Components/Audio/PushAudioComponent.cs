using UnityEngine;

namespace Game.Scripts
{
    public class PushAudioComponent : MonoBehaviour
    {
        [SerializeField] 
        private AudioSource _audioSource;
        
        [SerializeField]
        private AudioClip _pushAudio;

        [SerializeField]
        private AudioClip _tossAudio;

        [SerializeField]
        private PushComponent _pushComponent;
        
        private void OnEnable()
        {
            _pushComponent.OnStateChanged += HandlePushType;
        }

        private void OnDisable()
        {
            _pushComponent.OnStateChanged -= HandlePushType;
        }

        private void HandlePushType(Vector2 direction)
        {
            Play(direction == Vector2.up ? _tossAudio : _pushAudio);
        }

        private void Play(AudioClip audioClip)
        {
            if (audioClip)
            {
                _audioSource.PlayOneShot(audioClip);
            }
        }
    }
}