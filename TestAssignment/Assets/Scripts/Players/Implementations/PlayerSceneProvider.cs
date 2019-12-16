using Players;
using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public class PlayerSceneProvider : IPlayerSceneProvider
    {
        private readonly PlayerPanelHierarchy[] _hierarchies;

        public PlayerSceneProvider(PlayerPanelHierarchy[] hierarchies)
        {
            _hierarchies = hierarchies;
        }

        public IPlayerView GetView(int playerId)
        {
            return _hierarchies[playerId].character.GetComponent<IPlayerView>();
        }

        public Transform GetTransform(int playerId)
        {
            return _hierarchies[playerId].statsPanel;
        }

        public Button GetButton(int playerId)
        {
            return _hierarchies[playerId].attackButton;
        }
    }
}