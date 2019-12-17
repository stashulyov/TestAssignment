namespace Players
{
    public interface IPlayerStatChangedListener
    {
        void OnPlayerStatChanged(PlayerStatChangedSignal signal);
    }
}