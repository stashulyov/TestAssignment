using UnityEngine;
using UnityEngine.UI;

namespace Players
{
    public class PlayerSceneUiProvider : IAttackButtonProvider, ITransformProvider, IPlayerIdsProvider
    {
        private readonly PlayerPanelHierarchy[] _hierarchies;

        public PlayerSceneUiProvider(PlayerPanelHierarchy[] hierarchies)
        {
            _hierarchies = hierarchies;
        }

        public int[] GetPlayerIds()
        {
            var ids = new int[_hierarchies.Length];

            for (int i = 0; i < ids.Length; i++)
                ids[i] = i;

            return ids;
        }

        public Transform GetTransform(int playerId)
        {
            return _hierarchies[playerId].statsPanel;
        }

        public Button GetAttackButton(int playerId)
        {
            return _hierarchies[playerId].attackButton;
        }
    }
}