using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Components
{
    public class ForceSoundComponent : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _pushAudioClip;
        [SerializeField] private AudioClip _tossAudioClip;
        [FormerlySerializedAs("_forceActionComponent")]
        [SerializeField] private ForceComponent _forceComponent;
        
        private void OnEnable()
        {
            _forceComponent.OnPush += () => Play(_pushAudioClip);
            _forceComponent.OnToss += () => Play(_tossAudioClip);
        }

        private void OnDisable()
        {
            _forceComponent.OnPush -= () => Play(_pushAudioClip);
            _forceComponent.OnToss -= () => Play(_tossAudioClip);
        }

        private void Play(AudioClip audioClip)
        {
            _audioSource.PlayOneShot(audioClip);
        }
    }
}