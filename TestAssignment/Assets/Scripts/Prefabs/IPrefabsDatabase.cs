using UnityEngine;

namespace Prefabs
{
    public interface IPrefabsDatabase
    {
        GameObject Get(string prefabName);
    }
}