namespace Players
{
    public class PlayerModelFactory : IPlayerModelFactory
    {
        public IPlayerModel Create(int id)
        {
            var model = new PlayerModel();
            return model;
        }
    }
}