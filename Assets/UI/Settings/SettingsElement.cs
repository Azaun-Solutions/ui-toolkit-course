using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Settings
{
    public class SettingsElement : VisualElement
    {
        private AudioSettingsElement m_AudioSettings;
        
        public new class UxmlFactory : UxmlFactory<SettingsElement, UxmlTraits> {}

        public SettingsElement()
        {
            VisualTreeAsset visualTree = Resources.Load<VisualTreeAsset>("UI/Settings/Settings");
            visualTree.CloneTree(this);
            
            m_AudioSettings = this.Q<AudioSettingsElement>();

            Button saveButton = this.Q<Button>("save-button");
            saveButton.clicked += Save;
            Button resetButton = this.Q<Button>("reset-button");
            resetButton.clicked += Reset;
        }

        private void Save()
        {
            m_AudioSettings.Save();
        }

        private void Reset()
        {
            m_AudioSettings.Reset();
        }
    }
}