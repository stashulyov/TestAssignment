namespace Players
{
    public interface IPlayerBuffsBus
    {
        void Fire(PlayerBuffsAttachedSignal signal);
        void Fire(PlayerBuffsDetachedSignal signal);
    }
}