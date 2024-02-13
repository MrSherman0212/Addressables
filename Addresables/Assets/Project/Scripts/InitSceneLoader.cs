using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Project.Utility
{
    public class InitSceneLoader : MonoBehaviour
    {
        [SerializeField] private AssetReference _persistentSceneAsset;
        [SerializeField] private AddressablesManager _addressablesManager;

        private void Start()
        {
            Debug.Log("Init scene");
            _addressablesManager.LoadAddressableScene(_persistentSceneAsset);
        }
    }
}
