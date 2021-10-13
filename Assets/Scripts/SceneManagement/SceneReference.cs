﻿using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SceneManagement
{
    [System.Serializable]
    public class SceneReference : AssetReference
    {
        /// <summary>
        /// Construct a new AssetReference object.
        /// </summary>
        /// <param name="guid">The guid of the asset.</param>
        public SceneReference(string guid) : base(guid)
        {
        }

        /// <inheritdoc/>
        public override bool ValidateAsset(Object obj)
        {
#if UNITY_EDITOR
            var type = obj.GetType();
            return typeof(UnityEditor.SceneAsset).IsAssignableFrom(type);
#else
        return false;
#endif
        }
 
        /// <inheritdoc/>
        public override bool ValidateAsset(string path)
        {
#if UNITY_EDITOR
            var type = UnityEditor.AssetDatabase.GetMainAssetTypeAtPath(path);
            return typeof(UnityEditor.SceneAsset).IsAssignableFrom(type);
#else
        return false;
#endif
        }
 
#if UNITY_EDITOR
        /// <summary>
        /// Type-specific override of parent editorAsset.  Used by the editor to represent the asset referenced.
        /// </summary>
        public new UnityEditor.SceneAsset editorAsset => (UnityEditor.SceneAsset)base.editorAsset;
#endif
    }
}