using System;
using UnityEngine;

namespace SceneManagement
{
    [CreateAssetMenu(fileName = "SceneReadyChannel", menuName = "Channels/SceneReadyChannel", order = 0)]
    public class SceneReadyChannel : ScriptableObject
    {
        public event Action ready;

        public void Ready()
        {
            ready?.Invoke();
        }
    }
}