namespace Signals
{
    public interface IPlayerStatChangedListener
    {
        void OnPlayerStatChanged(PlayerStatChangedSignal signal);
    }
}