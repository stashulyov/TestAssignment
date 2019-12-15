using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public interface IUiBuilder
    {
        void Build(int[] playerIds, Transform[] parents, Button[] attackButtons);
    }
}