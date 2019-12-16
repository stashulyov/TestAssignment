namespace Players
{
    public class PlayerModelFactory : IPlayerModelFactory
    {
        public IPlayerModel Create(int playerId)
        {
            var model = new PlayerModel(playerId);
            return model;
        }
    }
}