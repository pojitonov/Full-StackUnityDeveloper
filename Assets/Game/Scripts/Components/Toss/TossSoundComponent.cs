using UnityEngine;

namespace Game
{
    public class TossSoundComponent : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _tossAudioClip;
        [SerializeField] private TossComponent _tossComponent;
        
        private void OnEnable()
        {
            _tossComponent.OnToss += () => Play(_tossAudioClip);
        }

        private void OnDisable()
        {
            _tossComponent.OnToss -= () => Play(_tossAudioClip);
        }

        private void Play(AudioClip audioClip)
        {
            _audioSource.PlayOneShot(audioClip);
        }
    }
}