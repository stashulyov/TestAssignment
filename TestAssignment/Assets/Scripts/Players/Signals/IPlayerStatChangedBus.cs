namespace Players
{
    public interface IPlayerStatChangedBus
    {
        void Fire(PlayerStatChangedSignal signal);
    }
}