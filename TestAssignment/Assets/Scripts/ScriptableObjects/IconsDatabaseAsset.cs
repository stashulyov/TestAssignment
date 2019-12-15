using Ui;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "IconsDatabaseAsset", menuName = "ScriptableObjects/IconsDatabaseAsset")]
    public class IconsDatabaseAsset : ScriptableObject
    {
        public Icon[] List;
    }
}