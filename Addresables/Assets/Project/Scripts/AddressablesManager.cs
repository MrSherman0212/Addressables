using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace Project.Utility
{
    public class AddressablesManager : MonoBehaviour
    {
        [SerializeField] private SceneInstance _sceneToUnload;

        private void UnloadAddressableScene()
        {
            SceneManager.UnloadSceneAsync(_sceneToUnload.Scene);
        }

        public void LoadAddressableScene(AssetReference newScene)
        {
            AsyncOperationHandle<SceneInstance> handle = Addressables.LoadSceneAsync(newScene, LoadSceneMode.Additive);
            handle.Completed += operationHandle =>
            {
                UnloadAddressableScene();
                _sceneToUnload = handle.Result;
            };
        }
    }
}
