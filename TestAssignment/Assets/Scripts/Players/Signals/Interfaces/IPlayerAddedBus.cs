namespace Players
{
    public interface IPlayerAddedBus
    {
        void Fire(PlayerAddedSignal signal);
    }
}