using SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.LoadingScreen
{
    [RequireComponent(typeof(UIDocument))]
    public class LoadingScreen : MonoBehaviour
    {
        private UIDocument m_UIDocument;
        private ProgressBar m_ProgressBar;
        [SerializeField] private DownloadState m_DownloadState;

        private void Awake()
        {
            m_UIDocument = GetComponent<UIDocument>();
            var root = m_UIDocument.rootVisualElement;
            m_ProgressBar = root.Q<ProgressBar>();
        }

        private void LateUpdate()
        {
            m_ProgressBar.value = m_DownloadState.progress;
        }
    }
}