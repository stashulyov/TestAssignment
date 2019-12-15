using ScriptableObjects;
using Ui;
using UnityEngine;

namespace Common
{
    public class MonoBehaviourServiceLocator : MonoBehaviour
    {
        public PlayerPanelHierarchy[] Hierarchies;
        public PrefabsDatabaseAsset PrefabsDatabaseAsset;
        public IconsDatabaseAsset IconsDatabaseAsset;
    }

    public class Infrastructure
    {
        private readonly MonoBehaviourServiceLocator _monoBehaviourServiceLocator;

        public Infrastructure(MonoBehaviourServiceLocator monoBehaviourServiceLocator)
        {
            _monoBehaviourServiceLocator = monoBehaviourServiceLocator;
        }

        public void BuildGraph()
        {
        }
    }
}