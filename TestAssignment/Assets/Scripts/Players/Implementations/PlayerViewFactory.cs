using Players;

namespace Common
{
    public class PlayerViewFactory : IPlayerViewFactory
    {
        private readonly PlayerPanelHierarchy[] _hierarchies;

        public PlayerViewFactory(PlayerPanelHierarchy[] hierarchies)
        {
            _hierarchies = hierarchies;
        }

        public IPlayerView Create(int playerId)
        {
            var playerView = _hierarchies[playerId].character.GetComponent<IPlayerView>();
            playerView.SetId(playerId);

            return playerView;
        }
    }
}