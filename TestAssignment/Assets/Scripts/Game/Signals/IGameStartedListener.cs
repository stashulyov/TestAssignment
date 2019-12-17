namespace Game
{
    public interface IGameStartedListener
    {
        void OnGameStarted(GameStartedSignal signal);
    }
}