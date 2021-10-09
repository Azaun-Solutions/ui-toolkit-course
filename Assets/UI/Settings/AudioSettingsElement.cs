using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

namespace UI.Settings
{
    public class AudioSettingsElement : VisualElement
    {
        public new class UxmlFactory : UxmlFactory<AudioSettingsElement, UxmlTraits> {}

        private Slider m_MasterVolumeSlider;
        private Slider m_MusicVolumeSlider;
        private Slider m_SfxVolumeSlider;

        private const string k_MasterVolume = "MasterVolume";
        private const string k_MusicVolume = "MusicVolume";
        private const string k_SfxVolume = "SFXVolume";

        public AudioSettingsElement()
        {
            VisualTreeAsset visualTree = Resources.Load<VisualTreeAsset>("UI/Settings/AudioSettings");
            visualTree.CloneTree(this);

            m_MasterVolumeSlider = this.Q<Slider>("master-volume-slider");
            m_MusicVolumeSlider = this.Q<Slider>("music-volume-slider");
            m_SfxVolumeSlider = this.Q<Slider>("sfx-volume-slider");

            AudioMixer audioMixer = Resources.Load<AudioMixer>("Audio/Main");

            m_MasterVolumeSlider.RegisterValueChangedCallback(evt =>
            {
                audioMixer.SetFloat(k_MasterVolume, Mathf.Log10(evt.newValue) * 20);
            });
            m_MusicVolumeSlider.RegisterValueChangedCallback(evt =>
            {
                audioMixer.SetFloat(k_MusicVolume, Mathf.Log10(evt.newValue) * 20);
            });
            m_SfxVolumeSlider.RegisterValueChangedCallback(evt =>
            {
                audioMixer.SetFloat(k_SfxVolume, Mathf.Log10(evt.newValue) * 20);
            });
        }
    }
}