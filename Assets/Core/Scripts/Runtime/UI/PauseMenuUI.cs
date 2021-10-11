using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Core.Scripts.Runtime.UI
{
    [RequireComponent(typeof(UIDocument))]
    public class PauseMenuUI : MonoBehaviour
    {
        private UIDocument m_UIDocument;
        public event Action resumed;
        public event Action openedMainMenu;

        private void Awake()
        {
            m_UIDocument = GetComponent<UIDocument>();
        }

        private void OnEnable()
        {
            var root = m_UIDocument.rootVisualElement;
            Button resumeButton = root.Q<Button>("resume-button");
            resumeButton.clicked += Resume;
            Button mainMenuButton = root.Q<Button>("main-menu-button");
            mainMenuButton.clicked += OpenMainMenu;
            Time.timeScale = 0;
        }

        private void OpenMainMenu()
        {
            openedMainMenu?.Invoke();
        }

        private void OnDisable()
        {
            Time.timeScale = 1;
        }

        private void Resume()
        {
            resumed?.Invoke();
        }
    }
}