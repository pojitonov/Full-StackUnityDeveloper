using UnityEngine;

namespace Game
{
    public class PushSoundComponent : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _pushAudioClip;
        [SerializeField] private PushComponent _pushComponent;
        
        private void OnEnable()
        {
            _pushComponent.OnPush += () => Play(_pushAudioClip);
        }

        private void OnDisable()
        {
            _pushComponent.OnPush -= () => Play(_pushAudioClip);
        }

        private void Play(AudioClip audioClip)
        {
            _audioSource.PlayOneShot(audioClip);
        }
    }
}