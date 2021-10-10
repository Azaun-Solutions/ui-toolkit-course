using SaveSystem.Scripts.Runtime;
using SaveSystem.Scripts.Runtime.Channels;
using SceneManagement;
using UnityEngine;

namespace DefaultNamespace
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameData m_GameData;
        [SerializeField] private SaveDataChannel m_SaveDataChannel;
        [SerializeField] private SceneReference m_MainMenuScene;
        [SerializeField] private LoadSceneChannel m_LoadSceneChannel;

        [SerializeField] private SceneReference m_ForestScene;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Save();
                m_LoadSceneChannel.Load(m_MainMenuScene);
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                m_LoadSceneChannel.Load(m_ForestScene);
            }
        }

        private void Save()
        {
            m_SaveDataChannel.Save();
            m_GameData.SaveToBinaryFile();
        }
    }
}