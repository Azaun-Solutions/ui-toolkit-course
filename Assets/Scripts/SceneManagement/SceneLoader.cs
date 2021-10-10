using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace SceneManagement
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private LoadSceneChannel m_LoadSceneChannel;

        private SceneReference m_SceneToLoad;
        private SceneReference m_CurrentSceneReference;

        private void OnEnable()
        {
            m_LoadSceneChannel.load += OnLoadScene;
        }

        private void OnDisable()
        {
            m_LoadSceneChannel.load -= OnLoadScene;
        }

        private void OnLoadScene(SceneReference sceneReference)
        {
            m_SceneToLoad = sceneReference;

            if (m_CurrentSceneReference != null)
            {
                m_CurrentSceneReference.UnLoadScene();
            }

            AsyncOperationHandle<SceneInstance> handle = sceneReference.LoadSceneAsync(LoadSceneMode.Additive);
            handle.Completed += OnSceneLoaded;
        }

        private void OnSceneLoaded(AsyncOperationHandle<SceneInstance> handle)
        {
            Scene scene = handle.Result.Scene;
            SceneManager.SetActiveScene(scene);
            m_CurrentSceneReference = m_SceneToLoad;
        }
    }
}