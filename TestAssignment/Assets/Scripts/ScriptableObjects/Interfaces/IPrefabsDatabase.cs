using UnityEngine;

namespace ScriptableObjects
{
    public interface IPrefabsDatabase
    {
        GameObject Get(string prefabName);
    }
}