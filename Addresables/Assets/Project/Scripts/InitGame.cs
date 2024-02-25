using Project.Utility;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class InitGame : MonoBehaviour
{
    [SerializeField] private AssetReference _initSceneAsset;
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private AssetReference _persistentScene;
    [SerializeField] private string _persistentSceneAsset;

    private void Start()
    {
        _sceneLoader.LoadScene(_persistentScene, _persistentSceneAsset, false);
    }
}
