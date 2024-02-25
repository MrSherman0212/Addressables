using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Collections.Generic;

namespace Project.Utility
{
    public class AddressablesLoader
    {
        private int _loadedAssetIndx, _loadedAssetsCount;

        public delegate void OnLoaded();
        public event OnLoaded OnAssetsLoaded;

        private void HandleAssetLoaded(AsyncOperationHandle<object> handle)
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                Debug.Log("Asset loaded: " + handle.Result.GetType().Name);
                _loadedAssetIndx++;
            }
            else
                Debug.LogError("Failed to load asset: " + handle.DebugName);
            if (_loadedAssetIndx >= _loadedAssetsCount)
                OnAssetsLoaded.Invoke();
        }

        public void LoadAssets(List<AssetReference> assetReferences)
        {
            if (assetReferences != null)
            {
                OnAssetsLoaded.Invoke();
                Debug.Log("no assets");
                return;
            }

            Debug.Log("assets are loading");
            _loadedAssetIndx = 0;
            _loadedAssetsCount = assetReferences.Count;
            foreach (var assetReference in assetReferences)
            {
                AsyncOperationHandle<object> handle = Addressables.LoadAssetAsync<object>(assetReference);
                handle.Completed += HandleAssetLoaded;
            }
            Debug.Log("Assets are loaded");
        }
    }
}