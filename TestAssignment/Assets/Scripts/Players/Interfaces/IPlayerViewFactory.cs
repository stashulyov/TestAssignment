namespace Players
{
    public interface IPlayerViewFactory
    {
        IPlayerView Create(int playerId);
    }
}