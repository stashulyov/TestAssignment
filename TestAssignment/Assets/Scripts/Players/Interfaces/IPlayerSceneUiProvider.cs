using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public interface IPlayerSceneUiProvider
    {
        Transform GetTransform(int playerId);
        Button GetButton(int playerId);
    }
}