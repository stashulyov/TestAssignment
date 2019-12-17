using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "PrefabsDatabaseAsset", menuName = "ScriptableObjects/PrefabsDatabaseAsset")]
    public class PrefabsDatabaseAsset : ScriptableObject
    {
        public GameObject[] List;
    }
}