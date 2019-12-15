using UnityEngine;

namespace Common
{
    public interface IPlayerViewBuilder
    {
        void Build(int[] playerIds, Animator[] animators);
    }
}