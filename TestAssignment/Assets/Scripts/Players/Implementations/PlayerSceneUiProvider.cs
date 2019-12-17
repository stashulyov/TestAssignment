using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public class PlayerSceneUiProvider : IPlayerSceneUiProvider
    {
        private readonly PlayerPanelHierarchy[] _hierarchies;

        public PlayerSceneUiProvider(PlayerPanelHierarchy[] hierarchies)
        {
            _hierarchies = hierarchies;
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