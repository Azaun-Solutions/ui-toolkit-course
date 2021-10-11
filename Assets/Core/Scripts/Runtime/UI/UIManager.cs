using Core.Input;
using UnityEngine;

namespace Core.Scripts.Runtime.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private InputReader m_InputReader;
        [SerializeField] private PauseMenuUI m_PauseMenu;

        private void OnEnable()
        {
            m_InputReader.paused += OnPause;
            m_InputReader.unpaused += OnUnpause;
            m_PauseMenu.resumed += OnUnpause;
        }

        private void OnDisable()
        {
            m_InputReader.paused -= OnPause;
            m_InputReader.unpaused -= OnUnpause;
            m_PauseMenu.resumed -= OnUnpause;
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
    }
}