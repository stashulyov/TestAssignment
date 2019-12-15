namespace Players
{
    public class PlayerModelFactory : IPlayerModelFactory
    {
        private readonly IPlayerModelDatabase _playerModelDatabase;

        public PlayerModelFactory(IPlayerModelDatabase playerModelDatabase)
        {
            _playerModelDatabase = playerModelDatabase;
        }

        public IPlayerModel Create(int id)
        {
            var model = new PlayerModel();
            _playerModelDatabase.Add(id, model);

            return model;
        }
    }
}