namespace Signals
{
    public interface IPlayerStatChangedBus
    {
        void Fire(PlayerStatChangedSignal signal);
    }
}