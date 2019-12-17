namespace Signals
{
    public interface IGameStartedBus
    {
        void Fire(GameStartedSignal signal);
    }
}