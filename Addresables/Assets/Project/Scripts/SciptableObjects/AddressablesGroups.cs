using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Project.Utility
{
    [CreateAssetMenu(fileName = "NewAssetPackDict", menuName = "AssetPack/AssetPackDict")]
    public class AddressablesGroups : ScriptableObject
    {
        [field: SerializeField] public List<AssetReferencePack> AssetPackList { get; private set; }
    }

    [Serializable]
    public struct AssetReferencePack
    {
        [field: SerializeField] public string AssetPackKey { get; private set; }
        [field: SerializeField] public List<AssetReference> AssetPack { get; private set; }
    }
}
