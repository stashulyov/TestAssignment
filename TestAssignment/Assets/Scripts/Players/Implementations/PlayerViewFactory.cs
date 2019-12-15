namespace Players
{
    public class PlayerViewFactory : IPlayerViewFactory
    {
        public IPlayerView Create(int id)
        {
            var view = new PlayerView();
            return view;
        }
    }
}