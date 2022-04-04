using UnityEngine;

namespace Spounka.Shooting
{
    public class AudioEffects : MonoBehaviour
    {
        [SerializeField, Range(-1.0f, 1.0f)] private float _pitchChange;
        [SerializeField] private bool _waitForFinish;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = transform.GetComponentInChildren<AudioSource>();
        }


        public void PlayAudio(AudioClip clip)
        {
            if (_audioSource.isPlaying && _waitForFinish) return;

            var randomPitch = Random.Range(-_pitchChange, _pitchChange);
            _audioSource.pitch = 1 + randomPitch;
            _audioSource.PlayOneShot(clip);
        }
    }
}