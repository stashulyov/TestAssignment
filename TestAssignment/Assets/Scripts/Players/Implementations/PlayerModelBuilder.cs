using Players;

namespace Common
{
    public class PlayerModelBuilder : IPlayerModelBuilder
    {
        private readonly IPlayerModelFactory _playerModelFactory;
        private readonly IPlayerModelDatabase _playerModelDatabase;

        public PlayerModelBuilder(IPlayerModelFactory playerModelFactory, IPlayerModelDatabase playerModelDatabase)
        {
            _playerModelFactory = playerModelFactory;
            _playerModelDatabase = playerModelDatabase;
        }

        public void Build(int[] playerIds)
        {
            foreach (var id in playerIds)
            {
                var playerModel = _playerModelFactory.Create(id);
                _playerModelDatabase.Add(id, playerModel);
            }
        }
    }
}