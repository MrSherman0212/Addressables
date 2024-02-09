using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace Project.Utility
{
    public class InitSceneLoader : MonoBehaviour
    {
        [SerializeField] private AssetReference _persistentSceneAsset;

        private void Start()
        {
            Debug.Log("Init scene");
            LoadAssetsAndTransition();
        }

        private void LoadAssetsAndTransition()
        {
            AsyncOperationHandle<SceneInstance> handle = Addressables.LoadSceneAsync(_persistentSceneAsset, LoadSceneMode.Additive);
            handle.Completed += operationHandle =>
            {
                TranstionToPersistentScene();
            };
        }

        private void TranstionToPersistentScene()
        {
            SceneManager.UnloadSceneAsync(gameObject.scene);

            //Scene persistentScene = SceneManager.GetSceneByPath(_persistentSceneAddress);
            //if (persistentScene.isLoaded)
            //    //SceneManager.LoadScene(_persistentSceneAddress, LoadSceneMode.Additive);
            //    return;
            //else
            //    SceneManager.SetActiveScene(persistentScene);
        }
    }
}
