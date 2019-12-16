namespace Signals
{
    public interface IPlayerAddedBus
    {
        void Fire(PlayerAddedSignal signal);
    }
}