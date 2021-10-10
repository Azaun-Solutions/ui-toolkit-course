using Core.Input;
using UnityEngine;

namespace Core.Scripts.Runtime.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private InputReader m_InputReader;

        private void OnEnable()
        {
            m_InputReader.paused += OnPause;
        }

        private void OnDisable()
        {
            m_InputReader.paused -= OnPause;
        }
        
        private void OnPause()
        {
            Debug.Log("Paused!");
        }
    }
}