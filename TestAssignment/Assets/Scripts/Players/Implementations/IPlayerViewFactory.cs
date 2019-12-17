using Players;

namespace Common
{
    public interface IPlayerViewFactory
    {
        IPlayerView Create(int playerId);
    }
}