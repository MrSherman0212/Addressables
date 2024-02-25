using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Project.Utility
{
    public class SceneLoader : MonoBehaviour
    {
        private Dictionary<string, List<AssetReference>> _assetsDictionary = new();
        private SceneInstance _loadedSceneInstance;
        private SceneInstance _previousSceneInstance = new();
        private bool _isSceneAdditive;

        [SerializeField] private AddressablesGroups _addressablesGroups;
        public AddressablesLoader AddressablesLoader { get; private set; } = new();

        private void Awake()
        {
            FillAssetsDictionary();
            AddressablesLoader.OnAssetsLoaded += ActivateScene;
        }

        private void FillAssetsDictionary()
        {
            foreach (var item in _addressablesGroups.AssetPackList)
                _assetsDictionary.Add(item.AssetPackKey, item.AssetPack);
        }

        private void ActivateScene()
        {
            if (_isSceneAdditive)
            {
                _loadedSceneInstance.ActivateAsync();
                Addressables.UnloadSceneAsync(_previousSceneInstance);
                _previousSceneInstance = _loadedSceneInstance;
            }
        }

        public void LoadScene(AssetReference sceneAsset, string assetPack, bool isAdditive = true)
        {
            _isSceneAdditive = isAdditive;
            if (isAdditive)
            {
                Addressables.LoadSceneAsync(sceneAsset, LoadSceneMode.Additive, false).Completed += handle =>
                {
                    _loadedSceneInstance = handle.Result;
                    AddressablesLoader.LoadAssets(_assetsDictionary[assetPack]);
                };
            }
            else
            {
                Addressables.LoadSceneAsync(sceneAsset, LoadSceneMode.Single).Completed += handle =>
                {
                    _loadedSceneInstance = handle.Result;
                    AddressablesLoader.LoadAssets(_assetsDictionary[assetPack]);
                };
            }
        }

        public void CheckDictionary(string assetPack)
        {
            Debug.Log(_assetsDictionary[assetPack] != null);
        }

        private void OnDisable()
        {
            AddressablesLoader.OnAssetsLoaded -= ActivateScene;
        }
    }
}
