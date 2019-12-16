using Players;
using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public interface IPlayerSceneProvider
    {
        IPlayerView GetView(int playerId);
        Transform GetTransform(int playerId);
        Button GetButton(int playerId);
    }
}