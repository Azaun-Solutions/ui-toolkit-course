using UnityEngine;
using UnityEngine.Audio;

namespace Core.Scripts.Runtime
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioMixer m_AudioMixer;
        
        private const string k_MasterVolume = "MasterVolume";
        private const string k_MusicVolume = "MusicVolume";
        private const string k_SfxVolume = "SFXVolume";

        private void Start()
        {
            m_AudioMixer.SetFloat(k_MasterVolume,
                Mathf.Log10(PlayerPrefs.HasKey(k_MasterVolume) ? PlayerPrefs.GetFloat(k_MasterVolume) : 1f) * 20);
            m_AudioMixer.SetFloat(k_MusicVolume,
                Mathf.Log10(PlayerPrefs.HasKey(k_MusicVolume) ? PlayerPrefs.GetFloat(k_MusicVolume) : 1f) * 20);
            m_AudioMixer.SetFloat(k_SfxVolume,
                Mathf.Log10(PlayerPrefs.HasKey(k_SfxVolume) ? PlayerPrefs.GetFloat(k_SfxVolume) : 1f) * 20);
        }
    }
}