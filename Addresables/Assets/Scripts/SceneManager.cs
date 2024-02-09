using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Project.Utility
{
    public class NewSceneManager : MonoBehaviour
    {
        [SerializeField] private AssetLabelReference assetRef;
        [SerializeField] private AssetBundle bundle;

        public void LoadAddressablesAsync()
        {
            Addressables.LoadAssetAsync<GameObject>(assetRef).Completed += (asyncOperationHandle) =>
            {
                if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
                    Instantiate(asyncOperationHandle.Result);
                else
                    Debug.Log("Failed loading!");
            };
        }
    }
}
