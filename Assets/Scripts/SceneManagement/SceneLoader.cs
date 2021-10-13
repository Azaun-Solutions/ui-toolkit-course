using System.Collections;
using SaveSystem.Scripts.Runtime;
using SaveSystem.Scripts.Runtime.Channels;
using SaveSystem.Scripts.Runtime.Core;
using SaveSystem.Scripts.Runtime.Data;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace SceneManagement
{
    public class SceneLoader : MonoBehaviour, ISavable<SceneData>
    {
        [SerializeField] private LoadSceneChannel m_LoadSceneChannel;

        [SerializeField] private GameData m_GameData;
        [SerializeField] private SaveDataChannel m_SaveDataChannel;
        [SerializeField] private LoadDataChannel m_LoadDataChannel;
        [SerializeField] private SceneReadyChannel m_SceneReadyChannel;
        [SerializeField] private DownloadState m_DownloadState;
        

        private SceneReference m_SceneToLoad;
        private SceneReference m_CurrentSceneReference;

        private void OnEnable()
        {
            m_LoadSceneChannel.load += OnLoadScene;
            m_SaveDataChannel.save += OnSaveData;
            m_LoadDataChannel.load += OnLoadData;
        }

        private void OnLoadData()
        {
            m_GameData.Load(this);
        }

        private void OnSaveData()
        {
            m_GameData.Save(this);
        }

        private void OnDisable()
        {
            m_LoadSceneChannel.load -= OnLoadScene;
            m_SaveDataChannel.save -= OnSaveData;
            m_LoadDataChannel.load -= OnLoadData;
        }

        private void OnLoadScene(SceneReference sceneReference)
        {
            m_SceneToLoad = sceneReference;

            if (m_CurrentSceneReference != null)
            {
                m_CurrentSceneReference.UnLoadScene();
            }

            StartCoroutine(LoadScene(sceneReference));
        }

        private IEnumerator LoadScene(SceneReference sceneReference)
        {
            AsyncOperationHandle<SceneInstance> handle = sceneReference.LoadSceneAsync(LoadSceneMode.Additive);
            handle.Completed += OnSceneLoaded;
            while (!handle.IsDone)
            {
                var status = handle.GetDownloadStatus();
                m_DownloadState.progress = status.Percent;
                yield return null;
            }
        }

        private void OnSceneLoaded(AsyncOperationHandle<SceneInstance> handle)
        {
            Scene scene = handle.Result.Scene;
            SceneManager.SetActiveScene(scene);
            m_CurrentSceneReference = m_SceneToLoad;
            m_SceneReadyChannel.Ready();
        }

        public SceneData data => new SceneData
        {
            id = m_CurrentSceneReference.AssetGUID
        };
        public void Load(SceneData sceneData)
        {
            OnLoadScene(new SceneReference(sceneData.id));
        }
    }
}