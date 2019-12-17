using Players;

namespace Game
{
    public class PlayerBuilder : IPlayerBuilder
    {
        private readonly IPlayerModelFactory _playerModelFactory;
        private readonly IPlayerViewFactory _playerViewFactory;
        private readonly IPlayerStatChangedBus _playerStatChangedBus;
        private readonly IPlayerModelDatabase _playerModelDatabase;
        private readonly IPlayerViewDatabase _playerViewDatabase;
        private readonly IPlayerAddedBus _playerAddedBus;

        public PlayerBuilder(IPlayerModelFactory playerModelFactory, IPlayerViewFactory playerViewFactory, IPlayerStatChangedBus playerStatChangedBus,
            IPlayerModelDatabase playerModelDatabase, IPlayerViewDatabase playerViewDatabase, IPlayerAddedBus playerAddedBus)
        {
            _playerModelFactory = playerModelFactory;
            _playerViewFactory = playerViewFactory;
            _playerStatChangedBus = playerStatChangedBus;
            _playerModelDatabase = playerModelDatabase;
            _playerViewDatabase = playerViewDatabase;
            _playerAddedBus = playerAddedBus;
        }

        public void Build(int playerId)
        {
            var playerModel = _playerModelFactory.Create(playerId);
            var playerRichModelDecorator = new PlayerRichModelDecorator(playerModel, _playerStatChangedBus);
            var playerView = _playerViewFactory.Create(playerId);

            _playerModelDatabase.Add(playerId, playerRichModelDecorator);
            _playerViewDatabase.Add(playerId, playerView);

            _playerAddedBus.Fire(new PlayerAddedSignal(playerId));
        }
    }
}