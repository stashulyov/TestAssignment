using Core;
using UnityEngine;

namespace ScriptableObjects
{
    public class PrefabsDatabase : ADatabase<string, GameObject>, IPrefabsDatabase
    {
        public PrefabsDatabase(PrefabsDatabaseAsset prefabsDatabaseAsset)
        {
            foreach (var prefab in prefabsDatabaseAsset.List)
                Add(prefab.name, prefab);
        }
    }
}