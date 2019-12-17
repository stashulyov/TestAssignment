using ScriptableObjects;
using Ui;
using UnityEngine;

namespace DependencyInjection
{
    public class MonoBehaviourServiceLocator : MonoBehaviour
    {
        public UiObjects UiObjects;
        public PrefabsDatabaseAsset PrefabsDatabaseAsset;
        public IconsDatabaseAsset IconsDatabaseAsset;
    }
}