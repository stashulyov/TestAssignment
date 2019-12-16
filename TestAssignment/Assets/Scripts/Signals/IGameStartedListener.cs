namespace Signals
{
    public interface IGameStartedListener
    {
        void OnGameStarted(GameStartedSignal signal);
    }
}