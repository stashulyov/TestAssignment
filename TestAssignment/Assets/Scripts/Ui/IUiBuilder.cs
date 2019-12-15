using UnityEngine;

namespace Common
{
    public interface IUiBuilder
    {
        void Build(int[] playerIds, Transform[] parents);
    }
}