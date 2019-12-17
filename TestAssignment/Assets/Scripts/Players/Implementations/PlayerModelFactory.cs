namespace Players
{
    public class PlayerModelFactory : IPlayerModelFactory
    {
        public IPlayerModel Create(int playerId)
        {
            var model = new PlayerAnemicModel(playerId);
            return model;
        }
    }
}