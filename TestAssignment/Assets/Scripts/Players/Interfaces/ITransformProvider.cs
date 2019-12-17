using UnityEngine;

namespace Players
{
    public interface ITransformProvider
    {
        Transform GetTransform(int playerId);
    }
}