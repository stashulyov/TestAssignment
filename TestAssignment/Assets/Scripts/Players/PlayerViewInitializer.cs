using Game;

namespace Players
{
    public class PlayerViewInitializer : IPlayerViewInitializer
    {
        private readonly IPlayerViewDatabase _playerViewDatabase;

        public PlayerViewInitializer(IPlayerViewDatabase playerViewDatabase)
        {
            _playerViewDatabase = playerViewDatabase;
        }

        public void InitializeView(int playerId)
        {
            var playerView = _playerViewDatabase.Get(playerId);
            playerView.Spawn();
        }
    }
}