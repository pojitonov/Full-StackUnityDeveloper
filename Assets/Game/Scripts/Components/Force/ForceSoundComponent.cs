using UnityEngine;

namespace Game.Scripts.Components
{
    public class ForceSoundComponent : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _pushAudioClip;
        [SerializeField] private AudioClip _tossAudioClip;
        [SerializeField] private ForceActionComponent _forceActionComponent;
        
        private void OnEnable()
        {
            _forceActionComponent.OnPush += () => Play(_pushAudioClip);
            _forceActionComponent.OnToss += () => Play(_tossAudioClip);
        }

        private void OnDisable()
        {
            _forceActionComponent.OnPush -= () => Play(_pushAudioClip);
            _forceActionComponent.OnToss -= () => Play(_tossAudioClip);
        }

        private void Play(AudioClip audioClip)
        {
            _audioSource.PlayOneShot(audioClip);
        }
    }
}