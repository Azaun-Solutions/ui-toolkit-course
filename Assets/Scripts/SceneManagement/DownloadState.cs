using UnityEngine;

namespace SceneManagement
{
    [CreateAssetMenu(fileName = "DownloadState", menuName = "State/DownloadState", order = 0)]
    public class DownloadState : ScriptableObject
    {
        [HideInInspector, SerializeField] public float progress;
    }
}