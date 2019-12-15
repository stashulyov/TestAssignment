namespace Players
{
    public interface IPlayerViewDatabase
    {
        void Add(int playerId, IPlayerView playerView);
    }
}