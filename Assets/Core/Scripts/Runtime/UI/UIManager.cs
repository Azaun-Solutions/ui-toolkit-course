using Core.Input;
using SaveSystem.Scripts.Runtime;
using SaveSystem.Scripts.Runtime.Channels;
using SceneManagement;
using UnityEngine;

namespace Core.Scripts.Runtime.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private InputReader m_InputReader;
        [SerializeField] private PauseMenuUI m_PauseMenu;
        [SerializeField] private GameData m_GameData;
        [SerializeField] private SaveDataChannel m_SaveDataChannel;
        [SerializeField] private SceneReference m_MainMenuScene;
        [SerializeField] private LoadSceneChannel m_LoadSceneChannel;

        private void Save()
        {
            m_SaveDataChannel.Save();
            m_GameData.SaveToBinaryFile();
        }

        private void OnEnable()
        {
            m_InputReader.paused += OnPause;
            m_InputReader.unpaused += OnUnpause;
            m_PauseMenu.resumed += OnUnpause;
            m_PauseMenu.openedMainMenu += OpenMainMenu;
        }

        private void OnDisable()
        {
            m_InputReader.paused -= OnPause;
            m_InputReader.unpaused -= OnUnpause;
            m_PauseMenu.resumed -= OnUnpause;
            m_PauseMenu.openedMainMenu -= OpenMainMenu;
        }
        
        private void OnPause()
        {
            m_PauseMenu.gameObject.SetActive(true);
            m_InputReader.EnableUIInput();
        }
        
        private void OnUnpause()
        {
            m_PauseMenu.gameObject.SetActive(false);
            m_InputReader.EnableGameplayInput();
        }

        private void OpenMainMenu()
        {
            Save();
            m_LoadSceneChannel.Load(m_MainMenuScene);
            OnUnpause();
        }
    }
}