using UnityEngine;
using UnityEngine.UI;

namespace SyncRun.Audio
{
    public class AudioManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private AudioSO audioSO;
        [SerializeField] private Slider backgroundVolumeSlider;
        [SerializeField] private Slider sfxVolumeSlider;

        private AudioSource backgroundMusicSource;

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);

            backgroundMusicSource = gameObject.AddComponent<AudioSource>();
            backgroundMusicSource.clip = audioSO.backgroundMusicClip;
            backgroundMusicSource.loop = true;
            backgroundMusicSource.volume = audioSO.backgroundMusicVolume;
            backgroundMusicSource.Play();

            if (backgroundVolumeSlider != null)
            {
                backgroundVolumeSlider.value = audioSO.backgroundMusicVolume;
                backgroundVolumeSlider.onValueChanged.AddListener(UpdateBackgroundVolume);
            }

            if (sfxVolumeSlider != null)
            {
                sfxVolumeSlider.value = audioSO.sfxVolume;
                sfxVolumeSlider.onValueChanged.AddListener(UpdateSFXVolume);
            }
        }

        private void UpdateBackgroundVolume(float volume)
        {
            audioSO.backgroundMusicVolume = volume;
            backgroundMusicSource.volume = volume;
            // Debug.Log($"Background Music Volume set to: {volume}");
        }

        private void UpdateSFXVolume(float volume)
        {
            audioSO.sfxVolume = volume;
            // Debug.Log($"SFX Volume set to: {volume}");
        }

        public void PlaySFX(SFXType sfxType)
        {
            AudioClip clip = audioSO.GetSFXClip(sfxType);
            if (clip != null)
            {
                AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, audioSO.sfxVolume);
            }
        }
    }
}
